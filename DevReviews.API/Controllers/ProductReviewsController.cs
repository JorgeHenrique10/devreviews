using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence;
using DevReviews.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/products/{productId}/productreviews")]
    public class ProductReviewsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductReviewsController(IProductRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int productId, int id)
        {
            var productReview = await _repository.GetReviewByIdAsync(id);

            if (productReview == null)
            {
                return NotFound();
            }

            var productDetails = _mapper.Map<ProductReviewDetailsViewModel>(productReview);

            return Ok(productDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Post(int productId, AddProductReviewInputModel model)
        {
            //var productReview = _mapper.Map<AddProductReviewInputModel, ProductReview>(model);
            var productReview = new ProductReview(model.Author, model.Rating, model.Comments, productId);

            await _repository.AddReviewAsync(productReview);

            return CreatedAtAction(nameof(GetById), new { id = productReview.Id, productId = productId }, model);
        }

    }
}