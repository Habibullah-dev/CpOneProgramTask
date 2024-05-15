
using ProgramTask.Dtos.Requests;
using ProgramTask.Models;

namespace ProgramTask.Test.Fixtures
{
    public static class ProgramFixture
    {
        public static EmployerProgram SampleProgram => new EmployerProgram
        {
            Id = "fb847c4f-3c86-4c39-9cf0-53292eea60f6",
            Title = "Test Program",
            Description = "This is a test program",
            PersonalInfo = new PersonalInfo()
            {
                Id = Guid.NewGuid().ToString(),

                FirstName = new ParagraphQuestion()
                {
                    Id = Guid.NewGuid().ToString(),
                    IsMandatory = true,
                    Question = "FirstName",
                    IsHidden = false,
                },
                LastName = new ParagraphQuestion()
                {
                    Id = Guid.NewGuid().ToString(),
                    IsMandatory = true,
                    Question = "LastName",
                    IsHidden = false,
                },
                Email = new ParagraphQuestion()
                {
                    Id = Guid.NewGuid().ToString(),
                    IsMandatory = true,
                    Question = "Email",
                    IsHidden = false,
                },

                Phone = new ParagraphQuestion()
                {
                    Id = Guid.NewGuid().ToString(),
                    IsMandatory = false,
                    Question = "Phone(without dial code)",
                    IsHidden = true,
                },
                Nationality = new DropdownQuestion()
                {
                    Id = Guid.NewGuid().ToString(),
                    IsMandatory = true,
                    Question = "Nationality",
                    IsHidden = false,
                    Choices = ["Nigeria", "China", "Russia", "Korean"]
                },
                IdNumber = new NumberQuestion()
                {
                    Id = Guid.NewGuid().ToString(),
                    IsMandatory = false,
                    Question = "Nationality",
                    IsHidden = true,
                },
                CurrentResidence = new DropdownQuestion()
                {
                    Id = Guid.NewGuid().ToString(),
                    IsMandatory = true,
                    Question = "Current Residence",
                    IsHidden = false,
                    Choices = ["Nigeria", "China", "Russia", "Korean"]
                },
                DateOfBirth = new ParagraphQuestion()
                {
                    Id = Guid.NewGuid().ToString(),
                    IsMandatory = false,
                    Question = "Date Of Birth",
                    IsHidden = true,
                },
                Gender = new DropdownQuestion()
                {
                    Id = Guid.NewGuid().ToString(),
                    IsMandatory = true,
                    Question = "Current Residence",
                    IsHidden = false,
                    Choices = ["Male", "Female"]
                },
                AdditionalQuestions = []
            },
        };

        public static EmployerProgramRequestDto SampleProgramRequestDto => new()
        {
             Title = "Sample Title",
             Description = "THis is a description",
             IsCurrentResidenceHidden = false,
             IsCurrentResidenceInternal = false,
             IsDateOfBirthHidden = true,
             IsDateOfBirthInternal = false,
             IsGenderInternal = true,
             IsGenderHidden = true,
             IsIdNumberInternal = false,
             IsNationalityHidden   = true,
             IsIdNumberHidden = true,
             IsNationalityInternal = false,
             IsPhoneHidden = true,
             IsPhoneInternal = true,
             AdditionalQuestionId = ["68cb2f64-a1f0-4063-887d-d993d23135fe"]
        };
    }


}
