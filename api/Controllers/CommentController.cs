using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.DTOs.Comment;
using api.Mappers;
using Microsoft.AspNetCore.Identity;
using api.Models;
using api.Extensions;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        private readonly UserManager<AppUser> _userManager;
        // Constructor
        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo, UserManager<AppUser> userManager)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var comments = await _commentRepo.GetAllAsync();

            var commentDto = comments.Select(c => c.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            // Validate the getById request
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDto commentDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _stockRepo.StockExists(stockId))
            {
                return BadRequest("Stock does not exist.");
            }

            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);

            var commentModel = commentDto.ToCommentFromCreate(stockId);
            commentModel.AppUserId = user.Id;

            await _commentRepo.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var comment = await _commentRepo.UpdateAsync(id, updateDto.ToCommentFromUpdate());

            if (comment == null)
            {
                return NotFound("Comment not found.");
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var commentModel = await _commentRepo.DeleteAsync(id);

            if (commentModel == null)
            {
                return NotFound("Comment does not exist.");
            }

            return Ok(commentModel);
        }
    }
}