using Microsoft.Extensions.Configuration;
using Mijn_stem_Back.Controllers;
using Mijn_stem_Back.Data.Services.Interfaces;
using Mijn_stem_Back.Models;
using Mijn_stem_Back.Data;
using Moq;
using MongoDB;
using System;
using System.Collections.Generic;
using Xunit;
using Mijn_stem_Back.Data.Services;
using System.Linq;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;

namespace MijnStemUnitTests
{
    public class MijnStemUnitTests
    {
        public List<Stelling> GetTestData()
        {
            var testStellingen = new List<Stelling>()
            {
                new Stelling{ StellingId = "1", Title = "Test", Type = "Radio" },
                new Stelling{ StellingId = "2", Type = "EensOn", Antwoorden = new List<StellingAntwoord>() { new StellingAntwoord() { UserId = "1"  }}  }
            };

            return testStellingen;
        }

        [Fact]
        public void GetStringId_TrueIfNameIsTest()
        {
            var stellingService = new Mock<IStellingServices>();
            stellingService.Setup(repo => repo.Get(It.IsAny<string>())).Returns((string x) => GetTestData().Find(stelling => stelling.StellingId == x));

            var controller = new StellingenController(stellingService.Object);

            var result = controller.Get("1");

            Assert.Equal("Test", result.Value.Title);
        }

        [Fact]
        public void GetAll_TrueIfListIsTwo()
        {
            var stellingService = new Mock<IStellingServices>();
            stellingService.Setup(repo => repo.Get()).Returns(new List<Stelling>
                { new Stelling() { StellingId = "1", Title = "Test 1" },
                { new Stelling() { StellingId = "2", Title = "Test 2"} } });

            var controller = new StellingenController(stellingService.Object);

            var result = controller.Get();

            Assert.Equal(2, result.Value.Count);
        }

        [Fact]
        public void Delete()
        {

            var stellingService = new Mock<IStellingServices>();
            stellingService.Setup(repo => repo.Get(It.IsAny<string>())).Returns((string x) => GetTestData().Find(stelling => stelling.StellingId == x));

            var controller = new StellingenController(stellingService.Object);


            var tests = controller.Delete("2");

            Assert.IsType<OkResult>(tests);
        }

        //[Fact]
        //public void Create()
        //{
        //    var stellingservice = new Mock<IStellingServices>();
        //    stellingservice.Setup(repo => repo.Get(It.IsAny<string>())).Returns((string x) => GetTestData().Find(stelling => stelling.StellingId == x));

        //    var controller = new StellingenController(stellingservice.Object);

        //    var result = controller.Create(new Stelling() { StellingId = "3" });

        //    Assert.Equal("3", result.Value.StellingId);
        //}

        [Fact]
        public void TestType()
        {
            var stellingService = new Mock<IStellingServices>();
            stellingService.Setup(repo => repo.Get(It.IsAny<string>())).Returns((string x) => GetTestData().Find(stelling => stelling.StellingId == x));

            var antwoordService = new Mock<IAntwoordServices>();
            antwoordService.Setup(repo => repo.GetType(It.IsAny<string>())).Returns((string x) => GetTestData().Where(stelling => stelling.Type == x).ToList());

            var controller = new StellingAntwoordController(stellingService.Object, antwoordService.Object);

            var result = controller.Get("EensOn", "2").Value.FirstOrDefault();
            var expected = new Stelling() { StellingId = "2", Type = "EensOn", Antwoorden = new List<StellingAntwoord>() { new StellingAntwoord() { UserId = "1" } } };

            Assert.Equal(expected.StellingId, result.StellingId);
        }
    }
}