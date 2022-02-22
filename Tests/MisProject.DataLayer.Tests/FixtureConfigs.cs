using AutoFixture;

namespace MisProject.DataLayer.Tests;

public class UserFixture : Fixture
{
    public UserFixture()
    {
        this.Register(() => new User()
        {
            UserName = "TestUser",
            // Get password from Mis.Password, otherwise set to AdminAdmin (Hash salt: MySalt)
            Password = Environment.GetEnvironmentVariable("Mis.Password") ?? "045e9902f2aca62f48117c43dfbd18cb",
            Email = "TestUser@Users.com",
            FirstName = "Test",
            LastName = "User",
            IsEmailConfirmed = true,
            IsPhoneNumberConfirmed = true,
            IsDeleted = false,
            ActiveCode = "4774d6cf92a744f9b181609003b31e7d",
            IdentityCode = "045f5b119de54909ab6630eae9a0b532",
            RegisterTime = DateTime.Now
        });
    }
}