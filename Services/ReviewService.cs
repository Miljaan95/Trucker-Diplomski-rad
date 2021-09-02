using AppDemo.Data.Domain;
using AppDemo.Models.Review;
using AppDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Services
{
    public class ReviewService : IReviewService
    {
        private IRepository<Review> _reviewRepository { get; set; }
        private IRepository<User> _userRepository { get; set; }
        private IRepository<DriverProfile> _driverRepository { get; set; }
        private IRepository<Tour> _tourRepository { get; set; }

        public ReviewService(IRepository<Review> reviewRepository,IRepository<User> userRepository,
                             IRepository<DriverProfile> driverRepository, IRepository<Tour> tourRepository)
        {
            _reviewRepository = reviewRepository;
            _userRepository = userRepository;
            _driverRepository = driverRepository;
            _tourRepository = tourRepository;
        }


        public int CreateReview(ReviewModel model)
        {
            try
            {
                Review newReview = new Review()
                {
                    Comment = model.Comment,
                    Rate = Convert.ToDecimal(model.Rate),
                    DateCreated = model.DateCreated,
                    DriverProfileId=model.DriverId,
                    UserId = model.UserId,
                    TourId=model.TourId
                };

                _reviewRepository.Insert(newReview);
                return newReview.Id;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public bool UpdateReview(ReviewModel model)
        {
            var userId = _userRepository.Get(model.UserId);
            var driverId = _driverRepository.Get(model.DriverId);
            var tourId = _tourRepository.Get(model.TourId);

            if (userId != null && driverId != null && tourId != null)
                try
                {
                    var review = _reviewRepository.Get(model.Id);

                    review.Comment = model.Comment;
                    review.Rate = Convert.ToDecimal(model.Rate);
                    review.DateCreated = model.DateCreated;
                    review.DriverProfileId = model.DriverId;
                    review.UserId = model.UserId;
                    review.TourId = model.TourId;

                    _reviewRepository.Update(review);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            else
                return false;
        }


        public bool DeleteReview(int Id)
        {
            var review = _reviewRepository.Get(Id);
            try
            {
                if (review == null)
                {
                    return false;
                }
                else
                {
                    _reviewRepository.Delete(review);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public decimal GetAverageRate(int userId)
        {
            var realUserId = _userRepository.Get(userId);
            if(realUserId != null)
            {
                var listOfRate = new List<Review>();
                listOfRate = _reviewRepository.GetAll().Where(r => r.UserId == userId).ToList();

                if(listOfRate != null)
                {
                    decimal rate = 0;
                    foreach(var r in listOfRate)
                    {
                        if(r.Rate != null)
                            rate = rate + r.Rate;
                    }
                    rate = rate / listOfRate.Count();
                    return rate;
                }
            }
            return 0;
        }
    }
}
