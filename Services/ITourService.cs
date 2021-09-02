using AppDemo.Models.Tour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Services
{
    public interface ITourService
    {
        int CreateTour(TourModel model);
        List<TourModel> GetTours();
        bool UpdateTour (TourModel model);
        bool DeleteTour(int Id);
        bool AssignDriver(TourModel model);
        bool AssignLoad(TourModel model);
    }
}
