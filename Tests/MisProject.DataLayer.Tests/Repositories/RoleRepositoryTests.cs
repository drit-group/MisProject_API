using System.Net.Mime;
using AutoFixture;

namespace MisProject.DataLayer.Tests.Repositories;

public class RoleRepositoryTests
{
    private readonly MisDbContext _db = MockData.DbContext;
    private RoleRepository _repository;

    public RoleRepositoryTests()
    {
        _repository = new RoleRepository(_db);
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
    public async Task GetAll_ShouldReturnsAllRoles()
    {
        // Act
        var result = await _repository.GetAll();
        var roles = result.ToList();

        // Assert
        roles.Should().NotBeNull().And.BeOfType<List<Role>>();
        roles.Should().HaveCount(UserSectionConfigs.RoleSeedList.Count);
    }

    [Test]
    public async Task GetById_ShouldReturnsRoleById()
    {
        // Arrange
        var fixture = new CustomFixture();
        var role = fixture.Create<Role>();
        await _repository.Create(role);

        // Act
        var result = await _repository.GetById(role.RoleId);

        // Assert
        result.Should().NotBeNull().And.BeOfType<Role>();
        result.RoleId.Should().Be(role.RoleId);

        // Cleanup
        await _repository.Delete(role);    
    }

    [Test]
    public async Task Create_ShouldCreateRole()
    {
        // Arrange
        var fixture = new CustomFixture();
        var role = fixture.Create<Role>();

        // Act
        var result = await _repository.Create(role);

        // Assert
        result.Should().NotBeNull().And.BeOfType<Role>();
        result.RoleId.Should().BeGreaterThan(0);

        // Cleanup
        await _repository.Delete(result);
    }

    [Test]
    public async Task Update_ShouldUpdateRole()
    {
        // Arrange
        var fixture = new CustomFixture();
        var role = fixture.Create<Role>();
        await _repository.Create(role);

        // Act
        var result = await _repository.Update(role);

        // Assert
        result.Should().NotBeNull().And.BeOfType<Role>();
        result.RoleId.Should().Be(role.RoleId);

        // Cleanup
        await _repository.Delete(result);
    }

    [Test]
    public async Task Delete_ShouldDeleteRole()
    {
        // Arrange
        var fixture = new CustomFixture();
        var role = fixture.Create<Role>();
        await _repository.Create(role);

        // Act
        var result = await _repository.Delete(role);

        // Assert
        result.Should().BeTrue();
        _repository.GetById(role.RoleId).Result.Should().BeNull();
    }

    [Test]
    public async Task Delete_ShouldReturnFalseIfRoleNotExists()
    {
        // Act
        var result = await _repository.Delete(1000);

        // Assert
        result.Should().BeFalse();
    }
}