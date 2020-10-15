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
    public class RecordsController : ControllerBase
    {
        private readonly IRecordRepository recordRepository;

        public RecordsController(IRecordRepository recordRepository)
        {
            this.recordRepository = recordRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetRecords()
        {
            try
            {
                return Ok(await recordRepository.GetAllRecords());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving Data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Record>> GetRecord(int id)
        {
            try
            {
                var result = await recordRepository.GetRecord(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database ");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Record>> CreateRecord(Record record)
        {
            try
            {
                if (record == null)
                {
                    return BadRequest();
                }

                var createdRecord = await recordRepository.AddRecord(record);
                return CreatedAtAction(nameof(GetRecord), new { id = createdRecord.RecordId }, createdRecord);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to create record data ");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Record>> DeleteRecord(int id)
        {
            try
            {
                var recordToDelete = await recordRepository.GetRecord(id);
                if (recordToDelete == null)
                {
                    return NotFound($"Record with ID ={id} not found");
                }
                return await recordRepository.DeleteRecord(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting data ");
            }
        }

    }
}
