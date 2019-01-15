using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Test;
namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            Class1 c1 = new Class1();
            Console.WriteLine(c1.GetInt());
            
            var ip = HttpContext.Connection.RemoteIpAddress;
            string serverIp = ip.ToString();
            serverIp = serverIp.Substring(serverIp.LastIndexOf(":")+1);
            Database db = new Database(serverIp);
            Console.WriteLine(serverIp);
            MySqlConnection conn = db.GetConnection();
            if(conn == null){
                Console.WriteLine("접속 오류..");
            }
            else{
                Console.WriteLine("접속 성공!");
            }
            return new string[] { "valuetest123", "valuetest234" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
