using System;

namespace FactoryMethodExample
{
    //abstract creator class that has abstract Factory Method that takes product type
    public abstract class Creator
    {
        public abstract ElectronicProduct CreateProduct(int type);
    }

    public class ConcreteCreator : Creator
    {
        public override ElectronicProduct CreateProduct(int type)
        {
            switch (type)
            {
                //return object Smartphone if type == 1
                case 1: return new Smartphone();
                //return object Laptop if type == 2
                case 2: return new Laptop();
                //return object SmartWatch if type == 3
                case 3: return new SmartWatch();
                default: throw new ArgumentException("InvalidType.", "type");
            }
        }
    }

    public abstract class ElectronicProduct
    {
    } //abstract class product

    //specific products with different implementations
    public class Smartphone : ElectronicProduct
    {
    }
    public class Laptop : ElectronicProduct
    {
    }
    public class SmartWatch : ElectronicProduct
    {
    }

    class MainApp
    {
        static void Main()
        {
            //create creator
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 3; i++)
            {
                //create products with type 1-3
                var product = creator.CreateProduct(i);
                Console.WriteLine("Where id = {0}, Created {1}", i, product.GetType());
            }
        }
    }
}