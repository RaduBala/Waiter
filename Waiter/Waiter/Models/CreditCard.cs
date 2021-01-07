using System;
using System.Collections.Generic;
using System.Text;

namespace Waiter.Models
{
    class CreditCard
    { 
        public string Number { get; set; }

        public int ExpirationYear { get; set; }

        public int ExpirationMounth { get; set; }

        public string Cvc { get; set; }
    }
}
