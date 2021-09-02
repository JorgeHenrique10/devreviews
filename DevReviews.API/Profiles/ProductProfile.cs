using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;

namespace DevReviews.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductReview, ProductReviewsViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductReview, ProductDetailsViewModel>();

        }
    }
}