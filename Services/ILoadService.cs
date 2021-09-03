using AppDemo.Models.Load;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Services
{
    public interface ILoadService
    {
        int CreateLoad(LoadModel model);
        List<LoadModel> GetLoads();
        bool UpdateLoad(LoadModel model);
        bool DeleteLoad(int Id);
    }
}
