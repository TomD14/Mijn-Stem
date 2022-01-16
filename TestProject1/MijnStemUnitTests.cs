using Microsoft.Extensions.Configuration;
using Mijn_stem_Back.Controllers;
using Mijn_stem_Back.Data.Services.Interfaces;
using Mijn_stem_Back.Models;
using Moq;
using MongoDB;
using System;
using System.Collections.Generic;
using Xunit;
using Mijn_stem_Back.Data.Services;

namespace MijnStemUnitTests
{
    public class MijnStemUnitTests
    {
        [Fact]
        public void Test1()
        {
            var stellingService = new Mock<IStellingServices>();
            stellingService.Setup(repo => repo.Get(It.IsAny<string>())).Returns(new Stelling() { StellingId = "1", Title = "Test"});

            var controller = new StellingenController(stellingService.Object);

            var result = controller.Get("1");

            Assert.Equal("Test", result.Value.Title);
        }
    }
}