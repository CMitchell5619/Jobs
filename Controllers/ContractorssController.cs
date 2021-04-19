using System;
using System.Collections.Generic;
using acontractorsTale.Models;
using acontractorsTale.Services;
using Microsoft.AspNetCore.Mvc;

namespace acontractorsTale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class contractorsController : ControllerBase
    {

        private readonly contractorsService _service;

        public contractorsController(contractorsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<contractor>> Get()
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
        public ActionResult<contractor> Get(int id)
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
        public ActionResult<contractor> Create([FromBody] contractor newProd)
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
        public ActionResult<contractor> Edit([FromBody] contractor updated, int id)
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
        public ActionResult<contractor> Delete(int id)
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

    }
}