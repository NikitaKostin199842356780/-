using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thetasksApi.Models
{
    public class thetasksItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
