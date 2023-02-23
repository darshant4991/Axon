using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApplication.Models
{
    public class Result
    {
        public int count { get; set; }
        //Darshan Starts
        public List<Response> entries { get; set; }
        //public List<Dictionary<string, object>> entries { get; set; }
        //Darshan Endss
    }
}
