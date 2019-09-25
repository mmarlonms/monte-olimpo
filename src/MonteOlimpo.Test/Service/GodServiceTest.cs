using Microsoft.Extensions.DependencyInjection;
using MonteOlimpo.Domain.Models;
using MonteOlimpo.Domain.Service;
using MonteOlimpo.Test.Base;
using Xunit;

namespace MonteOlimpo.Test
{
    public class GodServiceTest : MonteOlimpoTestFixture
    {
        private readonly IGodService GodService;

        public GodServiceTest()
        {
            this.GodService = this.ServiceProvider.GetRequiredService<IGodService>();
        }

        [Fact]
        public void InsertGod_ValidObject()
        {
            //Arrange
            var god = new God()
            {
                Idade = 10,
                Nome = "Zeus"
            };

            //Act
            var response = this.GodService.Create(god);

            //Assert
            Assert.NotNull(response.Id);
        }

        [Fact]
        public void UpdateGod_ValidObject()
        {
            //Arrange
            var god = new God()
            {
                Idade = 10,
                Nome = "Zeus"
            };

            var godInserted = this.GodService.Create(god);

            godInserted.Idade = 15;
            godInserted.Nome = "Afrodite";

            //Act
            var godUpdated = this.GodService.Update(godInserted);

            //Assert
            var getGod = this.GodService.GetByID(godInserted.Id.Value);
            Assert.Equal(getGod.Nome, godUpdated.Nome);
            Assert.Equal(getGod.Idade, godUpdated.Idade);
        }

        [Fact]
        public void DeleteGod_ValidObject()
        {
            //Arrange
            var god = new God()
            {
                Idade = 10,
                Nome = "Zeus"
            };

            var godInserted = this.GodService.Create(god);

            //Act
            this.GodService.Delete(godInserted.Id.Value);

            //Assert
            Assert.Empty(this.GodService.GetAll());
        }

        [Fact]
        public void ListGodsWithMoreTemYears_OneOrMoreGods()
        {
            //Arrange
            var god = new God()
            {
                Idade = 11,
                Nome = "Zeus"
            };

            this.GodService.Create(god);

            //Act
            //Assert
            Assert.NotEmpty(this.GodService.ListGodsWithMoreTemYears());
        }

        [Fact]
        public void ListGodsWithMoreTemYears_AnyGod()
        {
            //Arrange
            var god = new God()
            {
                Idade = 9,
                Nome = "Zeus"
            };

            this.GodService.Create(god);

            //Act
            //Assert
            Assert.Empty(this.GodService.ListGodsWithMoreTemYears());
        }

        [Fact]
        public void ListGodsWithMoreTemYearsAndPairAge_OneOrMoreGods()
        {
            //Arrange
            var god = new God()
            {
                Idade = 12,
                Nome = "Zeus"
            };

            this.GodService.Create(god);

            //Act
            //Assert
            Assert.NotEmpty(this.GodService.ListGodsWithMoreTemYearsAndPairAge());
        }

        [Fact]
        public void ListGodsWithMoreTemYearsAndPairAge_AnyGod()
        {
            //Arrange
            var god = new God()
            {
                Idade = 11,
                Nome = "Zeus"
            };

            this.GodService.Create(god);

            //Act
            //Assert
            Assert.Empty(this.GodService.ListGodsWithMoreTemYearsAndPairAge());
        }

        [Fact]
        public void ListGodsWithMoreTemYearsOrGodWithNameMercury_OneOrMoreGods()
        {
            //Arrange
            var god = new God()
            {
                Idade = 11,
                Nome = "Zeus"
            };

            var god2 = new God()
            {
                Idade = 8,
                Nome = "Mercurio"
            };

            this.GodService.Create(god);
            this.GodService.Create(god2);

            //Act
            //Assert
            Assert.Equal(2, this.GodService.ListGodsWithMoreTemYearsOrGodWithNameMercury().Count);
        }

        [Fact]
        public void ListGodsWithMoreTemYearsOrGodWithNameMercury_AnyGod()
        {
            //Arrange
            var god = new God()
            {
                Idade = 8,
                Nome = "Zeus"
            };

            this.GodService.Create(god);

            //Act
            //Assert
            Assert.Empty(this.GodService.ListGodsWithMoreTemYearsOrGodWithNameMercury());
        }


        [Fact]
        public void ListGodsWithMoreTemYearsAndPairAgeOrGodWithNameMercury_OneOrMoreGods()
        {
            //Arrange
            var god = new God()
            {
                Idade = 12,
                Nome = "Zeus"
            };

            var god2 = new God()
            {
                Idade = 8,
                Nome = "Mercurio"
            };

            var god3 = new God()
            {
                Idade = 15,
                Nome = "Afrodite"
            };

            this.GodService.Create(god);
            this.GodService.Create(god2);
            this.GodService.Create(god3);

            //Act
            //Assert
            Assert.Equal(2, this.GodService.ListGodsWithMoreTemYearsAndPairAgeOrGodWithNameMercury().Count);
        }

        [Fact]
        public void ListGodsWithMoreTemYearsAndPairAgeOrGodWithNameMercury_AnyGod()
        {
            //Arrange
            var god = new God()
            {
                Idade = 8,
                Nome = "Zeus"
            };

            this.GodService.Create(god);

            //Act
            //Assert
            Assert.Empty(this.GodService.ListGodsWithMoreTemYearsAndPairAgeOrGodWithNameMercury());
        }

    }
}