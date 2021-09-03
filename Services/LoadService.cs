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
        private IRepository<User> _userRepository { get; set; }

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

        public bool UpdateLoad(LoadModel model)
        {
            try
            {
                var load = _loadRepository.Get(model.Id);

                load.Length = model.Length;
                load.Height = model.Height;
                load.Weight = model.Weight;
                load.Width = model.Width;

                _loadRepository.Update(load);
                return true; 
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteLoad(int Id)
        {
            var load = _loadRepository.Get(Id);
            try
            {
                if (load == null)
                {
                    return false;
                }
                else
                {
                    _loadRepository.Delete(load);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<LoadModel> GetLoads()
        {
            var loadList = _loadRepository.GetAll().Select(x => new LoadModel()
            {
                Id = x.Id,
                Height=x.Height,
                Weight=x.Weight,
                Width=x.Width,
                Length=x.Length
            }).ToList();

            return loadList;
        }
    }
}
