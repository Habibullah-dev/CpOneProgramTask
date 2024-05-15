using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProgramTask.Controllers;
using ProgramTask.Models;
using ProgramTask.Services.Contracts;
using static ProgramTask.Test.Fixtures.QuestionFixture;

namespace ProgramTask.Test.QuestionControllerTest.Negative
{
    public partial class QuestionControllerTests
    {
        private readonly Mock<IQuestionRepository> _questionRepositoryMock;
        private readonly QuestionController _controller;

        public QuestionControllerTests()
        {
            _questionRepositoryMock = new Mock<IQuestionRepository>();
            _controller = new QuestionController(_questionRepositoryMock.Object);
        }

        [Fact]
        public async Task Get_ReturnsNotFoundResult_WithInValidId()
        {
            // Arrange
            string wrongId = "fb847c4f-3c86-4c39-9cf0-53292eea60f6";
            var expectedQuestion = SampleParagraphQuestion;

            _questionRepositoryMock.Setup(x => x.GetQuestionAsync(wrongId)).ReturnsAsync((ParagraphQuestion?)null);

            // Act
            var result = await _controller.Get(wrongId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();


        }
    }
}
