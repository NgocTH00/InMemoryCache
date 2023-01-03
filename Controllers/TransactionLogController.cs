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
    public class TransactionLogController : ControllerBase
    {
        private readonly DistributedCacheContext _context;
        public static List<string> KEYS = new();

        public TransactionLogController(DistributedCacheContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpPost("add")]
        public ActionResult Add()
        {
            var para = new ParaCust()
            {
                AParCusId = DateTime.Now.ToString(),
                AClientCode = Guid.NewGuid().ToString(),
                AParId = Guid.NewGuid().ToString() + '1',
                AStatus = ParaStatus.ChoDuyet,
                ACreateBy = DateTime.Now.ToString(),
                ACreateDte = DateTime.Now,
                AModifieBy = Guid.NewGuid().ToString() + '23',
                AModifieDte = DateTime.Now,
                AActiveBy = Guid.NewGuid().ToString() + "active by",
                AActiveDte = DateTime.Now,
                ACancelBy = Guid.NewGuid().ToString() + "ACancelBy",
                ACancelDte = DateTime.Now,
                ACustType = Guid.NewGuid().ToString() + "ACustType",
                AState = ParaCustState.AnToan
            };

            _context.SaveToCache(para, para.AClientCode, para.ACreateDte);
            return Ok(_context.GetFromCache<ParaCust>(para.AClientCode, para.ACreateDte));
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
