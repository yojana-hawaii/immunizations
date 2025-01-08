﻿using Application.Interface.Cdc;
using Domain.Models.Cdc;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CdcCvxController : ControllerBase
    {
        private readonly ICdcCvx _cdcCvx;

        public CdcCvxController(ICdcCvx cdcCvx)
        {
            _cdcCvx = cdcCvx;
        }

        // GET: api/<CdcCvxController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cdcCvx.GetAll());
        }

        // GET api/<CdcCvxController>/5
        [HttpGet("{code}")]
        public IActionResult Get(string code)
        {
            return Ok(_cdcCvx.GetByCvxCode(code));
        }

        // POST api/<CdcCvxController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CdcCvxController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CdcCvxController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
