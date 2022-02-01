using System.Net.Mime;
namespace MisProject.Helpers.Tests.Converters;

public class TextConvertersTests
{
    [Test]
    public void ToFixedText_WhenTextIsEmpty_ReturnsEmptyString()
    {
        // Arrange
        var text = string.Empty;

        // Act
        var result = text.ToFixedText();

        // Assert
        result.Should().BeEmpty();
    }

    [Test]
    public void ToFixedText_WhenTextIsWhitespace_ReturnsEmptyString()
    {
        // Arrange
        var text = " ";

        // Act
        var result = text.ToFixedText();

        // Assert
        result.Should().BeEmpty();
    }

    [TestCase("text", "TEXT")]
    [TestCase("Text", "TEXT")]
    [TestCase("Text ", "TEXT")]
    [TestCase(" Text", "TEXT")]
    [TestCase(" Text  ", "TEXT")]
    [TestCase("test.txt", "TEST.TXT")]
    [TestCase(" test.test@example.com  ", "TEST.TEST@EXAMPLE.COM")]
    [TestCase("\"@!#test\"<>", "\"@!#TEST\"<>")]
    public void ToFixedText_WhenTextIsNotNullNorEmptyNorWhitespace_ReturnsFixedText(string text, string excpected)
    {
        // Act
        var result = text.ToFixedText();

        // Assert
        result.Should().Be(excpected);
    }
}