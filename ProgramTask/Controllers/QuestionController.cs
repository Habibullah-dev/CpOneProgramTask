using Microsoft.AspNetCore.Mvc;
using ProgramTask.Dtos.Requests;
using ProgramTask.Extensions;
using ProgramTask.Models;
using ProgramTask.Services.Contracts;

namespace ProgramTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var item = await _questionRepository.GetQuestionAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }


        [HttpPost("paragraph")]
        public async Task<IActionResult> Create(ParagraphQuestionRequestDto item)
        {
            ParagraphQuestion question = item.ToParagraphQuestion();
            await _questionRepository.AddQuestionAsync(question);

            return CreatedAtAction(nameof(Get), new { id = question.Id }, question);
        }


        [HttpPost("number")]
        public async Task<IActionResult> Create(NumberQuestionRequestDto item)
        {
            NumberQuestion question = item.ToNumberQuestion();
            await _questionRepository.AddQuestionAsync(question);
            return CreatedAtAction(nameof(Get), new { id = question.Id }, question);
        }


        [HttpPost("dropdown")]
        public async Task<IActionResult> Create(DropdownQuestionRequestDto item)
        {
            DropdownQuestion question = item.ToDropdownQuestion();
            await _questionRepository.AddQuestionAsync(question);
            return CreatedAtAction(nameof(Get), new { id = question.Id }, question);
        }

        [HttpPost("yes-or-no")]
        public async Task<IActionResult> Create(YesOrNoQuestionRequestDto item)
        {
            YesOrNoQuestion question = item.ToYesOrNoQuestion();
            await _questionRepository.AddQuestionAsync(question);
            return CreatedAtAction(nameof(Get), new { id = question.Id }, question);
        }

        [HttpPost("multi-choice")]
        public async Task<IActionResult> Create(MultiChoiceQuestionRequestDto item)
        {
            MultiChoiceQuestion question = item.ToMultiChoiceQuestion();
            await _questionRepository.AddQuestionAsync(question);
            return CreatedAtAction(nameof(Get), new { id = question.Id }, question);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, BaseQuestion item)
        {
            await _questionRepository.UpdateItemAsync(id, item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(string id)
        {
            await _questionRepository.DeleteItemAsync(id);
            return NoContent();
        }

    }
}
