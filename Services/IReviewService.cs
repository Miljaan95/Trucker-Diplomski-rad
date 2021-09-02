using AppDemo.Data.Domain;
using AppDemo.Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Services
{
    public interface IReviewService
    {
        int CreateReview(ReviewModel model);
        bool UpdateReview(ReviewModel model);
        bool DeleteReview(int Id);
        decimal GetAverageRate(int userId);
    }
}
