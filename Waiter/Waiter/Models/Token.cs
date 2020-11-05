using System;
using System.Collections.Generic;
using System.Text;

namespace Waiter.Models
{
    class Token
    {
        public int Id { get; set; }

        public string AccessString { get; set; }

        public string Error { get; set; }

        public DateTime ExpiredDate { get; set; }

        public Token()
        {

        }
    }
}
