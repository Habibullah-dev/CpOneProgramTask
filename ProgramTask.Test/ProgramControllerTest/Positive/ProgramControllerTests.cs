using Microsoft.AspNetCore.Mvc;
using Moq;
using ProgramTask.Controllers;
using ProgramTask.Models;
using ProgramTask.Services.Contracts;

using static ProgramTask.Test.Fixtures.ProgramFixture;

namespace ProgramTask.Test.ProgramControllerTest.Positive
{
    public partial class ProgramControllerTests
    {
        private readonly Mock<IProgramRepository> _mockRepository;
        private readonly ProgramController _controller;

        public ProgramControllerTests()
        {
            _mockRepository = new Mock<IProgramRepository>();
            _controller = new ProgramController(_mockRepository.Object);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WhenProgramFound()
        {
            // Arrange
            string programId = "fb847c4f-3c86-4c39-9cf0-53292eea60f6";
            var program = SampleProgram;
            _mockRepository.Setup(repo => repo.GetEmployerProgramAsync(programId)).ReturnsAsync(program);

            // Act
            var result = await _controller.Get(programId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<EmployerProgram>(okResult.Value);
            Assert.Equal(programId, model.Id);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAtAction_WhenProgramCreated()
        {
            // Arrange
            var requestDto = SampleProgramRequestDto;
            var program = SampleProgram;
            _mockRepository.Setup(repo => repo.AddProgramAsync(requestDto)).ReturnsAsync(program);

            // Act
            var result = await _controller.Create(requestDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("Get", createdAtActionResult.ActionName);
            Assert.Equal(program.Id, createdAtActionResult?.RouteValues?["id"]);
            Assert.Equal(program, createdAtActionResult?.Value);
        }

        [Fact]
        public async Task CreateClientProgramInfo_ReturnsOkResult_WhenClientProgramInfoSaved()
        {
            // Arrange
            string programId = "fb847c4f-3c86-4c39-9cf0-53292eea60f6";
            var personalInfo = SampleProgram.PersonalInfo;

            // Act
            var result = await _controller.Create(programId, personalInfo);

            // Assert
            Assert.IsType<OkResult>(result);
            _mockRepository.Verify(repo => repo.SaveClientProgramInfoAsync(programId, personalInfo), Times.Once);
        }
    }
}
