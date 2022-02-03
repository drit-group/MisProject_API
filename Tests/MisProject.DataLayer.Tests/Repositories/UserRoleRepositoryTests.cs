namespace MisProject.DataLayer.Tests.Repositories;

public class UserRoleRepositoryTests
{
    private readonly MisDbContext _db = MockData.DbContext;
    private UserRoleRepository _repository;

    public UserRoleRepositoryTests()
    {
        _repository = new UserRoleRepository(_db);
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
    public async Task Create_ShouldReturnCreatedUserRole()
    {
        // Arrange
        var userRole = new UserRole(2, 1);

        // Act
        var result = await _repository.Create(userRole);

        // Assert
        result.Should().NotBeNull().And.BeOfType<UserRole>();
        result?.UserRoleId.Should().NotBe(0);

        var createdUserRole = await _db.UserRoles.FindAsync(result?.UserRoleId);
        createdUserRole.Should().NotBeNull().And.BeOfType<UserRole>();

        // Cleanup
        _db.UserRoles.Remove(createdUserRole);
        await _db.SaveChangesAsync();
    }

    [Test]
    public async Task DeleteExistingUserRole_ByObject_ShouldReturnTrue()
    {
        // Arrange
        var userRole = new UserRole(2, 1);
        await _db.UserRoles.AddAsync(userRole);
        await _db.SaveChangesAsync();

        // Act
        var result = await _repository.Delete(userRole);

        // Assert
        result.Should().BeTrue();
        var deletedUserRole = await _db.UserRoles.FindAsync(userRole.UserRoleId);
        deletedUserRole.Should().BeNull();
    }

    [Test]
    public async Task DeleteNotExistingUserRole_ByObject_ShouldReturnFalse()
    {
        // Arrange
        var userRole = new UserRole(2, 1);

        // Act
        var result = await _repository.Delete(userRole);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public async Task DeleteExistingUserRole_ById_ShouldReturnTrue()
    {
        // Arrange
        var userRole = new UserRole(2, 1);
        await _db.UserRoles.AddAsync(userRole);
        await _db.SaveChangesAsync();

        // Act
        var result = await _repository.Delete(userRole.UserRoleId);

        // Assert
        result.Should().BeTrue();
        var deletedUserRole = await _db.UserRoles.FindAsync(userRole.UserRoleId);
        deletedUserRole.Should().BeNull();
    }

    [Test]
    public async Task DeleteNotExistingUserRole_ById_ShouldReturnFalse()
    {
        // Act
        var result = await _repository.Delete(0);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public async Task GetAll_ShouldReturnAllUserRoles()
    {
        // Act
        var result = await _repository.GetAll();

        // Assert
        var userRoles = result.ToList();

        userRoles.Should().NotBeNull().And.HaveCount(UserSectionConfigs.UserRoleSeedList.Count);
    }

    [Test]
    public async Task GetById_ShouldReturnExistingUserRole()
    {
        // Arrange
        var userRole = new UserRole(2, 1);
        await _db.UserRoles.AddAsync(userRole);
        await _db.SaveChangesAsync();

        // Act
        var result = await _repository.GetById(userRole.UserRoleId);

        // Assert
        result.Should().NotBeNull().And.BeOfType<UserRole>();
        result.Should().BeSameAs(userRole);
    }
}