using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTaskRaketenstart
{
    public class Status
    {
        public Status(bool result, string name)
        {
            this.Result = result;
            this.Name = name;
        }

        public bool Result { get; set; }
        public string Name { get; set; }
    }
}
