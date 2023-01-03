using MemoryCacheDemo.CacheStore;
using MemoryCacheDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MemoryCacheDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly CacheContext _context;

        public NotificationController(
            CacheContext context, 
            ILogger<NotificationController> logger)
        {
            _logger = logger;
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpPost("add")]
        public ActionResult Add()
        {
            var notification = new Notification();
            _context.Save(notification, "123");
            return Ok(notification);
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.Get<Notification>("123"));
        }
    }
}
