using System;
using System.ComponentModel.DataAnnotations;

namespace acontractorsTale.Models
{
    public class job
    {
        public job()
        {

        }

        public string Name { get; set; }
        public string Commander { get; set; }
        public int Id { get; set; }
        public int? Defense { get; set; }

    }
}