using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Empty.Models
{
    public class Palacs
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public List<Palacs> Person { get; set; }
    }
}