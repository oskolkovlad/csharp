using System.Collections.Generic;

namespace CRM.BL.Model
{
    public class Seller
    {
        public Seller() { }

        public Seller(string name)
        {
            Name = name;
        }


        public int SellerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Check> Checks { get; set; }


        public override string ToString() => Name;
    }
}
