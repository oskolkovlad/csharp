namespace OperatorOverload_Const_ReadOnly
{
    // хлеб
    class Bread
    {
        public int Weight { get; set; } // масса

        public static Sandwich operator +(Bread bread, Butter butter)
        {
            return new Sandwich() { Weight = bread.Weight + butter.Weight };
        }
    }

    // масло
    class Butter
    {
        public int Weight { get; set; } // масса
    }

    // бутерброд
    class Sandwich
    {
        public int Weight { get; set; } // масса
    }
}
