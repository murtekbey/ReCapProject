using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FindeksScore:IEntity
    {
        public int FindeksScoreId { get; set; }
        public int CustomerId { get; set; }
        public int Score { get; set; }
    }
}
