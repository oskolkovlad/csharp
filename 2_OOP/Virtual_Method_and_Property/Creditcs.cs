namespace Virtual_Method_and_Property
{
    class Credit
    {
        public virtual decimal Sum { get; set; }
    }
    class LongCredit : Credit
    {
        private decimal sum;

        public override decimal Sum
        {
            get
            {
                return sum;
            }
            set
            {
                if (value > 1000)
                {
                    sum = value;
                }
            }
        }
    }
}
