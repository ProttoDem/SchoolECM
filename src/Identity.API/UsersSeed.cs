
namespace eShop.Identity.API;

public class UsersSeed(ILogger<UsersSeed> logger, UserManager<ApplicationUser> userManager) : IDbSeeder<ApplicationDbContext>
{
    public async Task SeedAsync(ApplicationDbContext context)
    {
        var alice = await userManager.FindByNameAsync("alice");

        if (alice == null)
        {
            alice = new ApplicationUser
            {
                UserName = "alice",
                Email = "AliceSmith@email.com",
                EmailConfirmed = true,
                City = "Redmond",
                Country = "U.S.",
                Id = "fbdd420e-d317-4899-bf25-c2965140ebd7",
                LastName = "Smith",
                Name = "Alice",
                PhoneNumber = "1234567890",
                ZipCode = "98052",
                State = "WA",
                Street = "15703 NE 61st Ct",
                Class = "8A",
                IsTeacher = false
            };

            var result = userManager.CreateAsync(alice, "Pass123$").Result;

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug("alice created");
            }
        }
        else
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug("alice already exists");
            }
        }

        var bob = await userManager.FindByNameAsync("bob");

        if (bob == null)
        {
            bob = new ApplicationUser
            {
                UserName = "bob",
                Email = "BobSmith@email.com",
                EmailConfirmed = true,
                City = "Redmond",
                Country = "U.S.",
                Id = "9e8c598d-9219-46e8-a378-f3e292b24d20",
                LastName = "Smith",
                Name = "Bob",
                PhoneNumber = "1234567890",
                ZipCode = "98052",
                State = "WA",
                Street = "15703 NE 61st Ct",
                IsTeacher = false
            };

            var result = await userManager.CreateAsync(bob, "Pass123$");

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug("bob created");
            }
        }
        else
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug("bob already exists");
            }
        }

        var jhon = await userManager.FindByNameAsync("jhon");

        if (jhon == null)
        {
            jhon = new ApplicationUser
            {
                UserName = "jhon",
                Email = "JhonSmith@email.com",
                EmailConfirmed = true,
                City = "Redmond",
                Country = "U.S.",
                Id = "bead59a7-4320-4e70-95b1-2ad6323ccc77",
                LastName = "Smith",
                Name = "Jhon",
                PhoneNumber = "1234567890",
                ZipCode = "98052",
                State = "WA",
                Street = "15703 NE 61st Ct",
                IsTeacher = true
            };

            var result = await userManager.CreateAsync(jhon, "Pass123$");

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug("jhon created");
            }
        }
        else
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug("bob already exists");
            }
        }

        var dafna = await userManager.FindByNameAsync("dafna");

        if (dafna == null)
        {
            dafna = new ApplicationUser
            {
                UserName = "dafna",
                Email = "DafnaSmith@email.com",
                EmailConfirmed = true,
                City = "Redmond",
                Country = "U.S.",
                Id = "7ca39d31-84fd-4d01-871b-7f0c5696a394",
                LastName = "Smith",
                Name = "Dafna",
                PhoneNumber = "1234567890",
                ZipCode = "98052",
                State = "WA",
                Street = "15703 NE 61st Ct",
                IsTeacher = true
            };

            var result = await userManager.CreateAsync(dafna, "Pass123$");

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug("dafna created");
            }
        }
        else
        {
            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug("bob already exists");
            }
        }
    }
}
