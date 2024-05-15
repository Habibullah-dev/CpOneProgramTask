namespace ProgramTask.Dtos.Requests
{
    public class NumberQuestionRequestDto
    {
        public string Question { get; set; } = string.Empty;

        public bool IsMandatory { get; set; }

        public bool IsHidden { get; set; } = false;

    }
}
