using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOOP_Lab11
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public abstract class Sandwich
    {
        public abstract decimal Price { get; }
        public abstract string Description { get; }
    }

    public class Bread : Sandwich
    {
        public override decimal Price => 10;
        public override string Description => "Хлеб";
    }

    public abstract class SandwichDecorator : Sandwich
    {
        protected Sandwich Sandwich { get; }

        protected SandwichDecorator(Sandwich sandwich)
        {
            Sandwich = sandwich;
        }
    }

    public class Cheese : SandwichDecorator
    {
        public Cheese(Sandwich sandwich) : base(sandwich) { }

        public override decimal Price => Sandwich.Price + 10;
        public override string Description => $"{Sandwich.Description}, сыр";
    }

    public class Mushrooms : SandwichDecorator
    {
        public Mushrooms(Sandwich sandwich) : base(sandwich) { }

        public override decimal Price => Sandwich.Price + 15;
        public override string Description => $"{Sandwich.Description}, грибы";
    }

    public class Vegetables : SandwichDecorator
    {
        public Vegetables(Sandwich sandwich) : base(sandwich) { }

        public override decimal Price => Sandwich.Price + 20;
        public override string Description => $"{Sandwich.Description}, овощи";
    }

    public class Sauces : SandwichDecorator
    {
        public Sauces(Sandwich sandwich) : base(sandwich) { }

        public override decimal Price => Sandwich.Price + 5;
        public override string Description => $"{Sandwich.Description}, соусы";
    }

    public class Bacon : SandwichDecorator
    {
        public Bacon(Sandwich sandwich) : base(sandwich) { }

        public override decimal Price => Sandwich.Price + 25;
        public override string Description => $"{Sandwich.Description}, бекон";
    }

    public class Salami : SandwichDecorator
    {
        public Salami(Sandwich sandwich) : base(sandwich) { }

        public override decimal Price => Sandwich.Price + 30;
        public override string Description => $"{Sandwich.Description}, салями";
    }

    public class Ham : SandwichDecorator
    {
        public Ham(Sandwich sandwich) : base(sandwich) { }

        public override decimal Price => Sandwich.Price + 20;
        public override string Description => $"{Sandwich.Description}, ветчина";
    }

    public class Beef : SandwichDecorator
    {
        public Beef(Sandwich sandwich) : base(sandwich) { }

        public override decimal Price => Sandwich.Price + 40;
        public override string Description => $"{Sandwich.Description}, ростбиф";
    }

    public class Chicken : SandwichDecorator
    {
        public Chicken(Sandwich sandwich) : base(sandwich) { }

        public override decimal Price => Sandwich.Price + 35;
        public override string Description => $"{Sandwich.Description}, курица";
    }

    public class Fish : SandwichDecorator
    {
        public Fish(Sandwich sandwich) : base(sandwich) { }

        public override decimal Price => Sandwich.Price + 45;
        public override string Description => $"{Sandwich.Description}, рыба";
    }
}
