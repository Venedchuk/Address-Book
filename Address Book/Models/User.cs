using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Address_Book.Models
{
    public class User
    {
        public int Id;
        public string Name;
        public IList<Phone> Phones;
    }
}