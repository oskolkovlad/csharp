using System.Collections.Generic;

namespace CRM.BL.Model
{
    public class Customer
    {
        public Customer() { }

        public Customer(string name)
        {
            Name = name;
        }


        public int CustomerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Check> Checks { get; set; }


        public override string ToString() => Name;
    }
}
