using System;
using System.ComponentModel.DataAnnotations;

namespace acontractorsTale.Models
{
    public class contractor
    {
        public contractor()
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public int jobId { get; set; }
        public int? KingdomCred { get; set; }
        public job job { get; set; }


    }
}