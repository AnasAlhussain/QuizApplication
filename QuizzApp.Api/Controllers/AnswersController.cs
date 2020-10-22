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
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerRepository answerRepository;

        public AnswersController(IAnswerRepository answerRepository)
        {
            this.answerRepository = answerRepository;
        }


        
        [HttpGet]
        public async Task<ActionResult> GetAllAnswers()
        {
            try
            {
                return Ok(await answerRepository.GetAnswers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving Answers from database");

            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAnswer(Answer answer)
        {
            try
            {
                if (answer == null)
                {
                    return BadRequest();
                }
                var createdAnswer = await answerRepository.AddAnswer(answer);
                return  CreatedAtAction(nameof(GetById), new { id = createdAnswer.AnswerId }, createdAnswer);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Answer>> GetById(int id)
        {
            try
            {
                var result = await answerRepository.GetAnswerBy(id);
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

        [HttpPut()]
        public async Task<ActionResult<Answer>> UpdateAnswer(Answer answer)
        {
            try
            {
                var answerToUpdate = await answerRepository.GetAnswerBy(answer.AnswerId);

                if (answerToUpdate == null)
                {
                    return NotFound($"Answer with ID ={answer.AnswerId} not found");
                }
                return await answerRepository.UpdateAnswer(answer);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error updating data");
            }
        }

    }
}
