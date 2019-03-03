using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASPNETCore2_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Employee emp)
        {
            return await Task.FromResult(Ok($"{emp.Name}-{emp.Age}"));
        }
    }

    public class Employee
    {
        public int Age { get; set; }

        public int SomeInt { get; set; }

        public string Name { get; set; }
    }
}