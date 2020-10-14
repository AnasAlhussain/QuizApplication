using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizzApp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving Data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employe>> GetById(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);
                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving Data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employe>> CreateEmploye(Employe employe)
        {
            try
            {
                if (employe == null)
                {
                    return BadRequest();
                }

                var createdEmployee = await employeeRepository.AddEmployee(employe);

                return CreatedAtAction(nameof(GetById), new { id = createdEmployee.EmployeeId }, createdEmployee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data ");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employe>> UpdateEmployee(int id, Employe employee)
        {

            try
            {
                if (id != employee.EmployeeId)
                {
                    return BadRequest();
                }
                var employeeToUpdate = await employeeRepository.GetEmployee(id);
                if (employeeToUpdate == null)
                {
                    return NotFound($"Employee with ID = {id} not found");
                }
                return await employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data ");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employe>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelet = await employeeRepository.GetEmployee(id);
                if (employeeToDelet == null)
                {
                    return NotFound($"Employee with ID ={id} not found");
                }
                return await employeeRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting data ");
            }
        }

    }
}
