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
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizRepository quizRepository;

        public QuizzesController(IQuizRepository quizRepository)
        {
            this.quizRepository = quizRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetQuizzes()
        {
            try
            {
                return Ok(await quizRepository.GetQuizzes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving Data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Quiz>> GetQuizById(int id)
        {
            try
            {
                var result = await quizRepository.GetById(id);
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
        [HttpPost]
       public async Task<ActionResult<Quiz>> CreateQuiz(Quiz quiz)
        {
            try
            {
                if (quiz == null)
                {
                    return BadRequest();
                }

               var createdquiz = await quizRepository.AddQuiz(quiz);

                return CreatedAtAction(nameof(GetQuizById), new { id = createdquiz.QizId }, createdquiz);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data ");
            }
            
        }


         [HttpPut("{id:int}")]
        public async Task<ActionResult<Quiz>> Updatequiz(int id, Quiz quiz)
        {
            try
            {
                if (id != quiz.QizId)
                {
                    return BadRequest("Quiz ID mismatch");
                }
                var quizToUpdate = await quizRepository.GetById(id);
                if (quizToUpdate == null)
                {
                    return NotFound($"Quiz with ID ={id} not found");
                }
                return await quizRepository.UpdateQuiz(quiz);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data ");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Quiz>> DeletQuiz(int id) 
        {
            try
            {
                var quizToDelet = await quizRepository.GetById(id);

                if (quizToDelet == null)
                {
                    return NotFound($"Quiz with ID = {id} not found");
                }
                return await quizRepository.DeleteQuiz(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting data ");
            }
        }
       
    }
}
