namespace PersonalTrainerPortal.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PersonalTrainerPortal.Models;
    using PersonalTrainerPortal.Models.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PersonalTrainerPortal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PersonalTrainerPortal.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            ApplicationUser apptrainer = new ApplicationUser()
            {
                UserName = "trainer@trainer.com",
                Email = "trainer@trainer.com"
            };

            ApplicationUser appClient1 = new ApplicationUser()
            {
                UserName = "client1@client.com",
                Email = "client1@client.com"
            };

            ApplicationUser appClient2 = new ApplicationUser()
            {
                UserName = "client2@client.com",
                Email = "client2@client.com"
            };

            context.Users.AddOrUpdate(
                u => u.UserName,
                apptrainer
                );

            context.Users.AddOrUpdate(
                u => u.UserName,
                appClient1
                );

            context.Users.AddOrUpdate(
                u => u.UserName,
                appClient2
                );

            context.SaveChanges();


            // Create a UserManager to add a password to the previously created user
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            //UserManage.AddPassword will also add password encryption
            UserManager.AddPassword(context.Users.Where(u => u.Email == "trainer@trainer.com").FirstOrDefault().Id, "P@ssword123");
            UserManager.AddPassword(context.Users.Where(u => u.Email == "client1@client.com").FirstOrDefault().Id, "P@ssword123");
            UserManager.AddPassword(context.Users.Where(u => u.Email == "client2@client.com").FirstOrDefault().Id, "P@ssword123");

            // Create RoleManager to create role for 'Admin'
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            RoleManager.Create(new IdentityRole
            {
                Name = "Admin"
            });

            RoleManager.Create(new IdentityRole
            {
                Name = "client"
            });

            RoleManager.Create(new IdentityRole
            {
                Name = "trainer"
            });

            context.SaveChanges();

            UserManager.AddToRole(context.Users.Where(u => u.Email == "trainer@trainer.com").FirstOrDefault().Id.ToString(), "trainer");
            UserManager.AddToRole(context.Users.Where(u => u.Email == "client1@client.com").FirstOrDefault().Id.ToString(), "client");
            UserManager.AddToRole(context.Users.Where(u => u.Email == "client2@client.com").FirstOrDefault().Id.ToString(), "client");

            context.SaveChanges();

            PersonalTrainer personalTrainer = new PersonalTrainer()
            {
                UserID = apptrainer.Id,
                FirstName = "trainer",
                LastName = "trainer",
                Email = apptrainer.Email

            };
            context.PersonalTrainers.Add(personalTrainer);
            context.SaveChanges();

            Client client1 = new Client()
            {
                UserID = appClient1.Id,
                FirstName = "client1",
                LastName = "client1",
                Email = appClient1.Email,
                PersonalTrainerID = personalTrainer.UserID
            };

            Client client2 = new Client()
            {
                UserID = appClient2.Id,
                FirstName = "client2",
                LastName = "client2",
                Email = appClient2.Email,
                PersonalTrainerID = personalTrainer.UserID
            };

            context.Clients.Add(client1);
            context.Clients.Add(client2);
            context.SaveChanges();
        }
    }
}
