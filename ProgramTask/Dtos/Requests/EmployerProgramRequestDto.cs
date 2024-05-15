namespace ProgramTask.Dtos.Requests
{
    public class EmployerProgramRequestDto
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsPhoneInternal { get; set; }

        public bool IsPhoneHidden { get; set; }

        public bool IsNationalityInternal { get; set; }

        public bool IsNationalityHidden { get; set; }

        public bool IsCurrentResidenceInternal { get; set; }

        public bool IsCurrentResidenceHidden { get; set; }

        public bool IsIdNumberInternal { get; set; }

        public bool IsIdNumberHidden { get; set; }

        public bool IsDateOfBirthInternal { get; set; }

        public bool IsDateOfBirthHidden { get; set; }

        public bool IsGenderInternal { get; set; }

        public bool IsGenderHidden { get; set; }

        public List<string> AdditionalQuestionId { get; set; } = [];
    }
}
