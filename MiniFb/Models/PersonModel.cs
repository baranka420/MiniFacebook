using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFb.Models
{
    public class PersonModel
    {
        public int PersonModelID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public int Age { get; set; }
        public string ImgUrl { get; set; }
        public Guid PersonId { get; set; }

    }
}