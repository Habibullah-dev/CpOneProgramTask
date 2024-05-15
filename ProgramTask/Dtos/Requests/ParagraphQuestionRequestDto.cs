namespace ProgramTask.Dtos.Requests
{
    public class ParagraphQuestionRequestDto
    {

        public string Question { get; set; } = string.Empty;

        public bool IsMandatory { get; set; }

        public bool IsHidden { get; set; } = false;

    }
}
