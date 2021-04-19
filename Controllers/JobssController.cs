using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using acontractorsTale.Models;
using acontractorsTale.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace acontractorsTale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class jobsController : ControllerBase
    {
        private readonly jobsService _service;
        private readonly contractorsService _ks;

        public jobsController(jobsService service, contractorsService ks)
        {
            _service = service;
            _ks = ks;
        }

        [HttpGet]
        public ActionResult<job> Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<job> Get(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public ActionResult<job> Create([FromBody] job newProd)
        {
            try
            {
                return Ok(_service.Create(newProd));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<job> Edit([FromBody] job updated, int id)
        {
            try
            {
                updated.Id = id;
                return Ok(_service.Edit(updated));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<job> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //https://localhost:5001/api/jobs/1/contractors
        [HttpGet("{id}/contractors")]
        public ActionResult<IEnumerable<contractor>> Getcontractors(int id)
        {
            try
            {
                return Ok(_ks.GetByjobId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}