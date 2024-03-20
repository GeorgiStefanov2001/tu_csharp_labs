using System;
using System.Collections.Generic;
using System.Text;

namespace PrCSharp_lab_2
{
    class PhoneContact
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Number { get; set; }

        public PhoneContact(string name, string id, string number)
        {
            this.Name = name;
            this.ID = id;
            this.Number = number;
        }

        public PhoneContact() { }
    }
}
