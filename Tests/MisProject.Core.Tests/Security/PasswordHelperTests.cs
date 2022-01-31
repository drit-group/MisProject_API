using System;
namespace MisProject.Core.Tests.Security;

public class PasswordHelperTests
{

#if !DEBUG
    [SetUp]
    public void SetUpRelease()
    {
        Environment.SetEnvironmentVariable("MD5_SALT", "ReleaseSalt");
    }

    [TearDown]
    public void TearDownRelease()
    {
        Environment.SetEnvironmentVariable("MD5_SALT", null);
    }

    [Test]
    public void HashPassword_EmptySalt_ThrowArgumentException()
    {
        // Arrange
        var password = "password";
        Environment.SetEnvironmentVariable("MD5_SALT", null);

        // Act
        Action ex = () => PasswordHelper.HashPasswordMd5(password);

        // Assert
        ex.Should().Throw<ArgumentException>().WithParameterName("salt");
    }
#endif

    [Test]
    public void HashPasswordMd5_Ok()
    {
        // Arrange
        var password = "password";

#if DEBUG
        var expected = "471e5243d0db300de1019fed26d3ffb1".ToUpper();
#else
        var expected = "d1fb8804db195aa2752f9d4bebc4c6ea".ToUpper();
#endif

        // Act
        var actual = PasswordHelper.HashPasswordMd5(password);
            
        // Assert
        actual.Should().Be(expected);
    }

    [Test]
    public void HashPasswordMd5_EmptyPassword_ThrowArgumentException()
    {
        // Arrange
        string password = "";

        // Act
        Action ex = () => PasswordHelper.HashPasswordMd5(password);

        // Assert
        var msg = ex.Should().Throw<ArgumentException>().WithParameterName(nameof(password));
    }
}