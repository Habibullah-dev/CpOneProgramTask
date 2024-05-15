using ProgramTask.Dtos.Requests;
using ProgramTask.Models;

namespace ProgramTask.Extensions
{
    public static class QuestionExtension
    {
        public static ParagraphQuestion ToParagraphQuestion(this ParagraphQuestionRequestDto item)
        {
            return new ParagraphQuestion
            {
                Id = Guid.NewGuid().ToString(),
                Question = item.Question,
                IsHidden = item.IsHidden,
                IsMandatory = item.IsMandatory,
            };
        }

        public static NumberQuestion ToNumberQuestion(this NumberQuestionRequestDto item)
        {
            return new NumberQuestion
            {
                Id = Guid.NewGuid().ToString(),
                Question = item.Question,
                IsHidden = item.IsHidden,
                IsMandatory = item.IsMandatory,
            };
        }

        public static YesOrNoQuestion ToYesOrNoQuestion(this YesOrNoQuestionRequestDto item)
        {
            return new YesOrNoQuestion
            {

                Id = Guid.NewGuid().ToString(),
                Question = item.Question,
                IsHidden = item.IsHidden,
                IsMandatory = item.IsMandatory,
            };
        }

        public static DropdownQuestion ToDropdownQuestion(this DropdownQuestionRequestDto item)
        {
            return new DropdownQuestion
            {
                Id = Guid.NewGuid().ToString(),
                Question = item.Question,
                IsHidden = item.IsHidden,
                IsMandatory = item.IsMandatory,
                Choices = item.Choices,
                IsOthersEnabled = item.IsOthersEnabled,

            };
        }

        public static MultiChoiceQuestion ToMultiChoiceQuestion(this MultiChoiceQuestionRequestDto item)
        {
            return new MultiChoiceQuestion
            {
                Id = Guid.NewGuid().ToString(),
                Question = item.Question,
                IsHidden = item.IsHidden,
                IsMandatory = item.IsMandatory,
                Choices = item.Choices,
                IsOthersEnabled = item.IsOthersEnabled,
                MaxChoice = item.MaxChoice,

            };
        }
    }
}
