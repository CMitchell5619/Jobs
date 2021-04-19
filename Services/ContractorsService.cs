using System;
using System.Collections.Generic;
using acontractorsTale.Models;
using acontractorsTale.Repositories;

namespace acontractorsTale.Services
{
    public class contractorsService
    {
        private readonly contractorsRepository _repo;

        public contractorsService(contractorsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<contractor> GetAll()
        {
            return _repo.GetAll();
        }

        internal contractor GetById(int id)
        {
            contractor data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        internal contractor Create(contractor newProd)
        {
            return _repo.Create(newProd);
        }

        internal contractor Edit(contractor updated)
        {

            // REVIEW
            contractor data = GetById(updated.Id);

            //null check properties you are editing in repo
            data.Description = updated.Description != null ? updated.Description : data.Description;
            data.Name = updated.Name != null ? updated.Name : data.Name;

            //remember if null checking an integer put an Elvis operator ? in the model following the type
            data.KingdomCred = updated.KingdomCred != null ? updated.KingdomCred : data.KingdomCred;

            return _repo.Edit(data);
        }
        internal string Delete(int id)
        {
            contractor data = GetById(id);
            _repo.Delete(id);
            return "delorted";
        }

        internal IEnumerable<contractor> GetByjobId(int id)
        {
            return _repo.GetByjobId(id);
        }
    }
}