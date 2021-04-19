using System;
using System.Collections.Generic;
using acontractorsTale.Models;
using acontractorsTale.Repositories;

namespace acontractorsTale.Services
{
    public class jobsService
    {
        private readonly jobsRepository _repo;

        public jobsService(jobsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<job> GetAll()
        {
            return _repo.GetAll();
        }

        internal job GetById(int id)
        {
            job data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        internal job Create(job newProd)
        {
            return _repo.Create(newProd);
        }

        internal job Edit(job updated)
        {

            // REVIEW
            job data = GetById(updated.Id);

            //null check properties you are editing in repo
            data.Commander = updated.Commander != null ? updated.Commander : data.Commander;
            data.Name = updated.Name != null ? updated.Name : data.Name;
            data.Defense = updated.Defense != null ? updated.Defense : data.Defense;

            return _repo.Edit(data);
        }
        internal string Delete(int id)
        {
            job data = GetById(id);
            _repo.Delete(id);
            return "delorted";
        }
    }
}