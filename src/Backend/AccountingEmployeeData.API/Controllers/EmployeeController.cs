using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingEmployeeData.Application;
using AccountingEmployeeData.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingEmployeeData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private EmployeeService _service;
        
        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult> Get(Guid id)
        {
            if (id == null)
            {
                return BadRequest(); 
            }
            return  Ok(await _service.Get(id));
        }
        
    }
}
