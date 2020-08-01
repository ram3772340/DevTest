using DeveloperTest.Database.Models;
using System;

namespace DeveloperTest.Models
{
    public class JobModel
    {
        public int JobId { get; set; }
        public int CustomerId { get; set; }

        public string Engineer { get; set; }

        public Customer Customer { get; set; }

        public DateTime When { get; set; }
    }
}
