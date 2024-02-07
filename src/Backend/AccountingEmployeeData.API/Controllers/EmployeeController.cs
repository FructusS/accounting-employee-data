using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingEmployeeData.Application;
using AccountingEmployeeData.Domain.Models;
using AccountingEmployeeData.Models;
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


        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (id == null)
            {
                return BadRequest(new ErrorResponse
                {
                    Error = $"{nameof(id)} is null"
                });
            }
            return  Ok(await _service.Get(id));
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EmployeeDto employee)
        {
            if (employee == null)
            {
                return BadRequest(new ErrorResponse
                {
                    Error = $"{nameof(employee)} is null"
                });
            }
            return Ok(await _service.Create(employee));
        }
        
        
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id,[FromBody] EmployeeDto employee)
        {
            if (id == null || employee == null)
            {
                return BadRequest(new ErrorResponse
                {
                    Error = $"{nameof(id)} or {nameof(employee)} is null"
                }); 
            }
            return Ok(await _service.Update(id,employee));
        }
        
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return  Ok(await _service.GetList());
        }
    }
}
