using Microsoft.AspNetCore.Mvc;
using CaveRegister.Models.Test;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaveRegister.Controllers
{
    [Route("api/test")]
    public class TestController : CaveRegisterController
    {
        public TestController()
        {
            
        }

        [HttpGet]
        [Route("")]
        public async Task<List<TestModel>> GetAsync()
        {
            return new List<TestModel>
            {
                new TestModel {Name = "John", BirthDate = new DateTime(1942, 11, 18)},
                new TestModel {Name = "Adams", BirthDate = new DateTime(1997, 05, 24)}
            };
        }
    }
}
