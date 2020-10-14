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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                return Ok(await departmentRepository.GetDepartments());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving Data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetById(int id)
        {
            try
            {
                var result = await departmentRepository.GetDepartment(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data ");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Department>> DeletDepartment(int id)
        {
            try
            {
                var departToDelete = await departmentRepository.GetDepartment(id);

                if (departToDelete == null )
                {
                    return NotFound($"Department with Id ={id} not found");
                }
                return await departmentRepository.DeleteDepartment(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting data ");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment(Department department)
        {
            try
            {
                if (department == null)
                {
                    return BadRequest();
                }
                var createdDepart = await departmentRepository.AddDepartment(department);
                return CreatedAtAction(nameof(GetById), new { id = createdDepart.DeptId }, createdDepart);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data ");
            }
        }
    }
}
