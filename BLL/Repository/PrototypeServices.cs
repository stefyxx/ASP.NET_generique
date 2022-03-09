using BLL.Handlers;
using BLL.Models;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Repository
{
    public class PrototypeServices : IRepository<Prototype>
    {
        private readonly IRepository<DAL.Models.Prototype> _repository;
        public PrototypeServices(IRepository<DAL.Models.Prototype> repository)
        {
            _repository = repository;
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Prototype Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public IEnumerable<Prototype> Get()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        public int Insert(Prototype entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(int id, Prototype entity)
        {
            _repository.Update(id, entity.ToDAL());
        }
    }
}
