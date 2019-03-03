using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASPNETCore2_0.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Employee emp)
        {
            return await Task.FromResult(Ok($"{emp.Name}-{emp.Age}"));
        }
    }
}