using System;
using System.Collections.Generic;

namespace DevReviews.API.Models
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(int id, string title, string description, decimal price, DateTime registeredAt, List<ProductReviewsViewModel> reviews)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            RegisteredAt = registeredAt;
            Reviews = reviews;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime RegisteredAt { get; private set; }

        public List<ProductReviewsViewModel> Reviews { get; private set; }
    }

    public class ProductReviewsViewModel
    {
        public ProductReviewsViewModel(int id, string author, string comments, int rating, DateTime registeredAt)
        {
            Id = id;
            Author = author;
            Comments = comments;
            Rating = rating;
            RegisteredAt = registeredAt;
        }

        public int Id { get; private set; }
        public string Author { get; private set; }
        public string Comments { get; private set; }
        public int Rating { get; private set; }
        public DateTime RegisteredAt { get; set; }
    }
}