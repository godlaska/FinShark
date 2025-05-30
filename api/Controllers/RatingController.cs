using api.Data;
using api.DTOs.Rating;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/rating")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;
        private readonly IRatingRepository _ratingRepo;
        public RatingController(UserManager<AppUser> userManager, IStockRepository stockRepo, IRatingRepository ratingRepo)
        {
            _userManager = userManager;
            _stockRepo = stockRepo;
            _ratingRepo = ratingRepo;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ratings = await _ratingRepo.GetAllAsync();

            if (ratings == null || !ratings.Any())
            {
                return NotFound("No ratings found.");
            }

            // Group by StockId and calculate average rating
            var averageRatings = ratings
                .GroupBy(r => r.StockId)
                .Select(g => new
                {
                    StockId = g.Key,
                    AverageRating = g.Average(r => r.StockRating)
                })
                .ToList();

            var ratingsDto = averageRatings.Select(ar => new
            {
                StockId = ar.StockId,
                AverageRating = Math.Round(ar.AverageRating, 2) // round to 2 decimals
            }).ToList();

            return Ok(ratingsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var rating = await _ratingRepo.GetByIdAsync(id);

            if (rating == null)
            {
                return NotFound($"Rating with ID {id} not found.");
            }

            return Ok(rating.ToRatingDto());
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateRatingDto ratingDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _stockRepo.StockExists(stockId))
                return BadRequest("Stock does not exist.");

            var ratingModel = ratingDto.ToRatingFromCreate(stockId);

            await _ratingRepo.CreateAsync(ratingModel);

            return CreatedAtAction(nameof(GetById), new { id = ratingModel.Id }, ratingModel.ToRatingDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatingRatingRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var rating = await _ratingRepo.GetByIdAsync(id);

            if (rating == null)
            {
                return NotFound($"Rating with ID {id} not found.");
            }

            return Ok(rating.ToRatingDto());
        }
    } 
}