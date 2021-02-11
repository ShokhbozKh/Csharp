﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Customer : User
    {
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public double? Discount { get; set; }
        public int CustomerTypeId { get; set; }

        [EnumDataType(typeof(CustomerType))]
        public CustomerType CustomerType { get; set; }


        public override void BookTicket()
        {
            throw new NotImplementedException();
        }
    }
}
