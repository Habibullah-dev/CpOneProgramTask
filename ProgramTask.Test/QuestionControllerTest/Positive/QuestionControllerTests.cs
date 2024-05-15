using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProgramTask.Controllers;
using ProgramTask.Models;
using ProgramTask.Services.Contracts;
using static ProgramTask.Test.Fixtures.QuestionFixture;

namespace ProgramTask.Test.QuestionControllerTest.Positive
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
        public async Task Get_ReturnsOkObjectResult_WithValidId()
        {
            // Arrange
            string id = "68cb2f64-a1f0-4063-887d-d993d23135fe";
            var expectedQuestion = SampleParagraphQuestion;

            _questionRepositoryMock.Setup(x => x.GetQuestionAsync(id)).ReturnsAsync(expectedQuestion);

            // Act
            var result = await _controller.Get(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualQuestion = Assert.IsType<ParagraphQuestion>(okResult.Value);
            actualQuestion.Should().BeEquivalentTo(expectedQuestion);
        }

        [Theory]
        [InlineData("paragraph")]
        [InlineData("number")]
        [InlineData("dropdown")]
        [InlineData("yes-or-no")]
        [InlineData("multi-choice")]
        public async Task Create_ReturnsCreatedAtAction_WithValidItem(string endpoint)
        {
            // Arrange
            dynamic item = GetSampleQuestionRequestDto(endpoint);

            _questionRepositoryMock.Setup(x => x.AddQuestionAsync(It.IsAny<BaseQuestion>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(item);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("Get", createdAtActionResult.ActionName);
        }

        [Fact]
        public async Task Update_ReturnsNoContentResult_WithValidId()
        {
            // Arrange
            string validId = "88f927e4-0f4d-488b-97fe-72773443cd37";
            var item = new BaseQuestion();
            _questionRepositoryMock.Setup(x => x.UpdateItemAsync(validId, item)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(validId, item);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteItem_ReturnsNoContentResult_WithValidId()
        {
            // Arrange
            string validId = "88f927e4-0f4d-488b-97fe-72773443cd37";
            _questionRepositoryMock.Setup(x => x.DeleteItemAsync(validId)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteItem(validId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }


    }
}
