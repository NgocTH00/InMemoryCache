using MemoryCacheDemo.CacheStore;
using MemoryCacheDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryCacheDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributedCacheController : ControllerBase
    {
        private readonly DistributedCacheContext _context;
        public static List<string> KEYS = new();

        public DistributedCacheController(DistributedCacheContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpPost("add")]
        public ActionResult Add()
        {
            var message = new Message();
            _context.SaveToCache(message, message.Id, "demo");
            return Ok(_context.GetFromCache<Message>(message.Id, "demo"));
        }

        [HttpGet("keys")]
        public ActionResult Keys()
        {
            return Ok(KEYS);
        }

        [HttpGet]
        public ActionResult All()
        {
            List<Message> list = new();
            KEYS.ForEach(x => list.Add(_context.GetFromCache<Message>(x)));
            return Ok(list);
        }
    }
}
