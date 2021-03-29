using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public Payment()
        {
            PaymentDate = DateTime.Now;
        }
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
