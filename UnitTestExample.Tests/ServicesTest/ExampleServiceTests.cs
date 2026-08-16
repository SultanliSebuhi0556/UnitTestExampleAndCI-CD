using FluentAssertions;
using FluentAssertions.Extensions;
using Moq;
using UnitTestExample.Entities;
using UnitTestExample.Services;

namespace UnitTestExample.Tests.ServicesTest;

public class ExampleServiceTests
{
    private readonly ExampleService _service;
    public ExampleServiceTests()
    {
        var mockExternalService = new Mock<IExampleExternalService>();
        mockExternalService.Setup(x => x.ExampleExternalMethodA()).Returns(true);
        _service = new ExampleService(mockExternalService.Object);
    }

    [Fact]
    public void ExampleService_ExampleMethodA_ReturnsString()
    {
        //Act
        var result = _service.ExampleMethodA();

        //Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Be("Success: Code Executed!");
        result.Should().Contain("Success", Exactly.Once());
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 3, 5)]
    public void ExampleService_ExampleMethodB_ReturnsInt(int numberA, int numberB, int expected)
    {
        //Act
        var result = _service.ExampleMethodB(numberA, numberB);

        //Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void ExampleService_ExampleMethodC_ReturnsDate()
    {
        //Act
        var result = _service.ExampleMethodC();

        //Assert
        result.Should().BeAfter(15.August(2026));
        result.Should().BeBefore(15.August(2027));
    }

    [Fact]
    public void ExampleService_ExampleMethodD_ReturnsObject()
    {
        //Arrange
        var expected = new ExampleEntity()
        {
            Text = "Hello",
            Number = 10
        };

        //Act
        var result = _service.ExampleMethodD();

        //Assert
        result.Should().BeOfType<ExampleEntity>();
        result.Should().BeEquivalentTo(expected);
        result.Number.Should().Be(10);
    }

    [Fact]
    public void ExampleService_ExampleMethodE_ReturnsArray()
    {
        //Arrange
        var expected = new ExampleEntity()
        {
            Text = "Hello1",
            Number = 11
        };

        //Act
        var result = _service.ExampleMethodE();

        //Assert
        result.Should().BeOfType<ExampleEntity[]>();
        result.Should().ContainEquivalentOf(expected);
        result.Should().Contain(x => x.Number == 11);
    }

    [Fact]
    public void ExampleService_ExampleMethodF_ReturnsString()
    {
        //Act
        var result = _service.ExampleMethodF();

        //Assert
        result.Should().Be("Success: Code Executed");
    }
}