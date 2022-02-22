using AutoFixture;
using MisProject.Helpers.Converters;

namespace MisProject.DataLayer.Tests.Repositories;

public class UserRepositoryTests
{
    private readonly MisDbContext _db = MockData.DbContext;
    private UserRepository _repository;

    public UserRepositoryTests()
    {
        _repository = new UserRepository(_db);
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _db.Database.EnsureDeleted();
        _db.Database.EnsureCreated();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _db.Database.EnsureDeleted();
    }

    [TearDown]
    public void TearDown()
    {
        _db.ChangeTracker.Clear();
    }

    [Test]
    public async Task Create_ShouldReturnCreatedUser()
    {
        // Arrange
        var fixture = new CustomFixture();
        var user = fixture.Create<User>();

        // Act
        var result = await _repository.Create(user);

        // Assert
        result.Should().NotBeNull().And.BeOfType<User>();
        result?.UserId.Should().NotBe(0);

        // Cleanup
        await _repository.Delete(result.UserId);
    }

    [Test]
    public async Task GetAll_ShouldReturnAllExistingUsers()
    {
        // Act
        var result = await _repository.GetAll();
        var users = result.ToList();

        // Assert
        users.Should().NotBeNull().And.BeOfType<List<User>>();
        result.Should().HaveCount(UserSectionConfigs.UserSeedList.Count);
    }

    [Test]
    public async Task GetById_ShouldReturnExistingUser()
    {
        // Arrange
        var fixture = new CustomFixture();
        var user = fixture.Create<User>();
        await _repository.Create(user);

        // Act
        var result = await _repository.GetById(user.UserId);

        // Assert
        result.Should().NotBeNull().And.BeOfType<User>();
        result?.UserId.Should().Be(user.UserId);

        // Cleanup
        await _repository.Delete(user);
    }

    [Test]
    public async Task Update_ShouldReturnUpdatedUser()
    {
        // Arrange
        var fixture = new CustomFixture();
        var user = fixture.Create<User>();
        await _repository.Create(user);

        // Act
        user.FirstName = "Updated";
        var result = await _repository.Update(user);

        // Assert
        result.Should().NotBeNull().And.BeOfType<User>();
        result?.FirstName.Should().Be("Updated");

        // Cleanup
        await _repository.Delete(user.UserId);
    }

    [Test]
    public async Task DeleteById_ShouldReturnTrue()
    {
        // Arrange
        var fixture = new CustomFixture();
        var user = fixture.Create<User>();
        await _repository.Create(user);

        // Act
        var result = await _repository.Delete(user.UserId);

        // Assert
        result.Should().BeTrue();
    }

    public async Task Delete_ShouldReturnTrue()
    {
        // Arrange
        var fixture = new CustomFixture();
        var user = fixture.Create<User>();
        await _repository.Create(user);

        // Act
        var result = await _repository.Delete(user);

        // Assert
        result.Should().BeTrue();
    }
}