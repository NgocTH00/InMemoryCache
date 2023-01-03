using MemoryCacheDemo.CacheStore;
using MemoryCacheDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemoryCacheDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MemoryCacheContext _context;

        public MessageController(MemoryCacheContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpPost("add")]
        public ActionResult Add()
        {
            var message = new Message();
            _context.AddData(message, new[] { message.Id.ToString()});
            return Ok(message);
        }

        [HttpGet("all")]
        public ActionResult All()
        {
            return Ok(_context.GetDatas<Message>());
        }

        [HttpGet]
        public ActionResult Get(Guid id)
        {
            return Ok(_context.GetData<Message>(new[] { id.ToString() }));
        }

        [HttpGet("total")]
        public ActionResult TotalMessage()
        {
            return Ok(_context.GetDatas<Message>().Count());
        }

        [HttpGet("keys")]
        public ActionResult Keys()
        {
            return Ok(_context.GetCacheKeys(typeof(Message)));
        }
    }
}
