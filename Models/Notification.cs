using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryCacheDemo.Models
{
    public class Notification
    {
        public Notification()
        {
            Id = Guid.NewGuid();
            NotificationContent = DateTime.Now.ToString() + " - Notification - " + Id;
        }
        public Guid Id { get; set; }
        public string NotificationContent { get; set; }
    }
}
