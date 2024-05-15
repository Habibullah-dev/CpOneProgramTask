using Microsoft.VisualStudio.TestPlatform.TestHost;
using ProgramTask.Dtos.Requests;
using ProgramTask.Models;
using System;


namespace ProgramTask.Test.Fixtures
{
    public static class QuestionFixture
    {
        public static ParagraphQuestion SampleParagraphQuestion => new ParagraphQuestion()
        {
            Id = "68cb2f64-a1f0-4063-887d-d993d23135fe",
            IsHidden = false,
            IsMandatory = false,
            Question = "What is Your Name",
            Type = "Paragraph",
            Value = ""
        };

        public static dynamic GetSampleQuestionRequestDto(string endpoint)
        {
            return endpoint switch
            {
                "paragraph" => new ParagraphQuestionRequestDto { Question = "How are you doing?", IsHidden = false, IsMandatory = true },
                "number" => new NumberQuestionRequestDto { Question = "How old are you?", IsHidden = false, IsMandatory = true },
                "dropdown" => new DropdownQuestionRequestDto { Choices = new List<string> { "Option 1", "Option 2", "Option 3" } },
                "yes-or-no" => new YesOrNoQuestionRequestDto { Question = "Yes or no question", IsMandatory = true, IsHidden = false },
                "multi-choice" => new MultiChoiceQuestionRequestDto { Question = "Sample multiple-choice question", Choices = new List<string> { "Option A", "Option B", "Option C" } },
                _ => throw new ArgumentException("Invalid endpoint name", nameof(endpoint)),
            };
        }
    }


}
