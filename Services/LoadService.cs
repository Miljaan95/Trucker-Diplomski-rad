using AppDemo.Data.Domain;
using AppDemo.Models.Load;
using AppDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Services
{
    public class LoadService : ILoadService
    {
        private IRepository<Load> _loadRepository { get; set; }

        public LoadService(IRepository<Load> loadRepository)
        {
            _loadRepository = loadRepository;
        }

        public int CreateLoad(LoadModel model)
        {
            try
            {
                Load load = new Load()
                {
                    Length = model.Length,
                    Height = model.Height,
                    Weight = model.Weight,
                    Width = model.Width
                };

                _loadRepository.Insert(load);
                return load.Id;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
