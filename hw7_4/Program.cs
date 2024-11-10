using System;

namespace Decorator
{
    //"Component"
    abstract class ChristmasTree
    {
        public abstract void Decorate();
    }

    //"ConcreteComponent"
    class SimpleChristmasTree : ChristmasTree
    {
        public override void Decorate()
        {
            Console.WriteLine("Simple Christmas tree");
        }
    }
    //"Decorator"
    abstract class TreeDecorator : ChristmasTree
    {
        protected ChristmasTree tree;

        public void SetComponent(ChristmasTree tree)
        {
            this.tree = tree;
        }
        public override void Decorate()
        {
            if (tree != null)
            {
                tree.Decorate();
            }
        }
    }
    //"ConcreteDecoratorA"
    class DecorationDecorator : TreeDecorator
    {
        private List<string> decorations = new List<string>();
        public void AddDecoration(string decoration)
        {
            decorations.Add(decoration);
        }
        public override void Decorate()
        {
            base.Decorate();
            Console.Write("DecorationDecorator.Decorate(): ");
            foreach (string decoration in decorations)
            {
                Console.Write(decoration + " ");
            }
            Console.WriteLine();
        }
    }

    //"ConcreteDecoratorB"
    class GarlandDecorator : TreeDecorator
    {
        public override void Decorate()
        {
            base.Decorate();
            Console.Write("GarlandDecorator.Decorate(): ");
            LightUp();
        }
        void LightUp()
        {
            Console.WriteLine("Christmas tree glows");
        }
    }

    class Program
    {
        static void Main()
        {
            //Create ConcreteCmomponent and two Decorators
            SimpleChristmasTree tree = new SimpleChristmasTree();
            DecorationDecorator dec = new DecorationDecorator();
            GarlandDecorator garl = new GarlandDecorator();

            dec.AddDecoration("baubles");
            dec.AddDecoration("bells");
            dec.AddDecoration("snowflakes");

            //Link decorators
            dec.SetComponent(tree);
            garl.SetComponent(dec);

            garl.Decorate();

            //Wait for user
            Console.Read();
        }
    }
}