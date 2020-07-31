using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Address_Book.Models
{
    public class Phone
    {
        public Phone(int id, int ownerId, string phoneNumber, bool isActive = false) {
            Id = id;
            OwnerId = ownerId;
            PhoneNumber = phoneNumber;
            IsActive = isActive;
        }

        public Phone()
        {
        }

        public int Id;
        public int OwnerId;
        public string PhoneNumber;
        public bool IsActive;
    }
}