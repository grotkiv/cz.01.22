using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingDayDal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradingDayWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradingDayController : ControllerBase
    {
        Archive archive = new Archive("https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml");

        // GET: api/<TradingDayController>
        [HttpGet]
        public IEnumerable<TradingDay> Get()
        {
            return archive.TradingDays;
        }

        // GET api/<TradingDayController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TradingDayController>
        [HttpPost]
        public void Post([FromBody] TradingDay day)
        {
            archive.TradingDays.Add(day);
        }

        // PUT api/<TradingDayController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TradingDayController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        
    }
}
