namespace Cutting_edge_webapp.Migrations
{
    using Cutting_edge_webapp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cutting_edge_webapp.DAL.LocalizationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Cutting_edge_webapp.DAL.LocalizationContext context)
        {
            //http://www.asp.net/mvc/tutorials/getting-started-with-ef-5-using-mvc-4/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application

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

            var countries = new List<Country>
            {
                new Country{ Name = "Poland" },
                new Country{ Name = "Germany" },
                new Country{ Name = "Italy" },
                new Country{ Name = "USA" }
            };

            countries.ForEach(s => context.Countries.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var cities = new List<City>
            {
                new City { Name = "Warsaw", CountryID = countries.Single( s => s.Name == "Poland").CountryID },
                new City { Name = "Berlin", CountryID = countries.Single( s => s.Name == "Germany").CountryID },
                new City { Name = "Rome", CountryID = countries.Single( s => s.Name == "Italy").CountryID },
                new City { Name = "New York", CountryID = countries.Single( s => s.Name == "USA").CountryID }
            };

            cities.ForEach(s => context.Cities.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var streets = new List<Street>
            {
                new Street { Name = "Aleje Jerozolimskie", CityID = cities.Single( s => s.Name == "Warsaw").CountryID },
                new Street { Name = "Thomass Mann Strasse", CityID = cities.Single( s => s.Name == "Berlin").CountryID },
                new Street { Name = "Via Druso", CityID = cities.Single( s => s.Name == "Rome").CountryID },
                new Street { Name = "Wall Street", CityID = cities.Single( s => s.Name == "New York").CountryID }
            };

            streets.ForEach(s => context.Streets.AddOrUpdate(p => p.Name, s));

            var news = new List<News>
            {
                new News{ Text = "First news", CreateDate = DateTime.Now },
                new News{ Text = "Second news", CreateDate = DateTime.Now },
                new News{ Text = "Third news", CreateDate = DateTime.Now }
            };

            news.ForEach(s => context.News.AddOrUpdate(p => p.Text, s));

            context.SaveChanges();
        }
    }
}
