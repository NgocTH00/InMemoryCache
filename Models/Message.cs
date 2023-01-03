using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryCacheDemo.Models
{
    public class Message
    {
        public Message()
        {
            Id = Guid.NewGuid();
            Content = DateTime.Now.ToString()+ " - Hello - " + Id;
        }
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
