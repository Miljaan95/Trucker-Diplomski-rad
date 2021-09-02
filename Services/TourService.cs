using AppDemo.Data;
using AppDemo.Data.Domain;
using AppDemo.Models.Tour;
using AppDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Services
{
    public class TourService : ITourService
    {
        private IRepository<Tour> _tourRepository { get; set; }
        private IRepository<User> _userRepository { get; set; }
        private IRepository<DriverProfile> _driverRepository { get; set; }
        private IRepository<Load> _loadRepository { get; set; }

        public TourService(IRepository<Tour> tourRepository, IRepository<User> userRepository, IRepository<DriverProfile> driverRepository,
            IRepository<Load> loadRepository)
        {
            _tourRepository = tourRepository;
            _userRepository = userRepository;
            _driverRepository = driverRepository;
            _loadRepository = loadRepository;
        }

        public int CreateTour(TourModel model)
        {
            try
            {
                Tour newTour = new Tour()
                {
                    DateCreated = model.DateCreated,
                    Distance = model.Distance,
                    From = model.From,
                    To = model.To,
                    Price = model.Price,
                    TypeTour = model.Type,
                    UserId = model.UserId
                };

                _tourRepository.Insert(newTour);
                return newTour.Id;
            }
            catch(Exception e)
            {
                return 0;
            }
        }

        public List<TourModel> GetTours()
        {
            var tourList = _tourRepository.GetAll().Select(x => new TourModel() 
            {
                Id = x.Id,
                LoadId = x.LoadId, 
                UserId = x.UserId,
                DriverId = x.DriverProfileId,
                From = x.From,
                To = x.To,
                DateCreated = x.DateCreated,
                Distance = x.Distance,
                Price = x.Price ?? 0,
                Type = x.TypeTour
            }).ToList();

            return tourList;
        }

        public bool UpdateTour(TourModel model)
        {
            var tourUser = _userRepository.Get(model.UserId);

            if (tourUser.RoleId == 1 || tourUser.RoleId == 3)
                try
                {
                    var tour = _tourRepository.Get(model.Id);

                    tour.From = model.From;
                    tour.To = model.To;
                    tour.Distance = model.Distance;
                    tour.Price = model.Price;
                    tour.DriverProfileId = model.DriverId;
                    tour.LoadId = model.LoadId;
                    tour.DriverProfileId = model.DriverId;
                    tour.TypeTour = model.Type;

                    _tourRepository.Update(tour);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            else
                return false;

        }

        public bool DeleteTour(int Id)
        {
            var tour = _tourRepository.Get(Id);
            try
            {
                if (tour == null)
                {
                    return false;
                }
                else
                {
                    _tourRepository.Delete(tour);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool AssignDriver(TourModel model)
        {
            try
            {
                var tour = _tourRepository.Get(model.Id);
                var driver = _driverRepository.Get((int)model.DriverId);

                if (tour == null || driver == null)
                {
                    return false;
                }
                else
                {
                    tour.DriverProfileId = model.DriverId;
                    _tourRepository.Update(tour);
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool AssignLoad(TourModel model)
        {
            try
            {
                var tour = _tourRepository.Get(model.Id);
                var load = _loadRepository.Get((int)model.DriverId);

                if (tour == null || load == null)
                {
                    return false;
                }
                else
                {
                    tour.LoadId = model.LoadId;
                    _tourRepository.Update(tour);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
