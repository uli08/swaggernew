using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace apiWebApplication1.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _Employeeservice;

        public EmployeeController(IEmployeeService Employeeservice)
        {
            _Employeeservice = Employeeservice; 
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get() {

            return Ok(
               _Employeeservice.GetAll()
           );


        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(
              _Employeeservice.Get(id)
          );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Employee model)
        {
            return Ok(
                _Employeeservice.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Employee model)
        {
            return Ok(
                _Employeeservice.Add(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _Employeeservice.Delete(id)
            );
        }
    }
}
