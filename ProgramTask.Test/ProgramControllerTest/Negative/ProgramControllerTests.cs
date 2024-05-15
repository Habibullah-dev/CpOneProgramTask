using Microsoft.AspNetCore.Mvc;
using Moq;
using ProgramTask.Controllers;
using ProgramTask.Models;
using ProgramTask.Services.Contracts;

namespace ProgramTask.Test.ProgramControllerTest.Negative
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
        public async Task Get_ReturnsNotFound_WhenProgramNotFound()
        {
            // Arrange
            string programId = "fb847c4f-3c86-4c39-9cf0-53292eea60f6";
            _mockRepository.Setup(repo => repo.GetEmployerProgramAsync(programId)).ReturnsAsync((EmployerProgram?)null);

            // Act
            var result = await _controller.Get(programId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}