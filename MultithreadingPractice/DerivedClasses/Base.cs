using System;
using Col = System.Collections.Generic;

namespace MultithreadingPractice.DerivedClasses
{
    public class Base
    {
        public virtual void Print()
        {
            Console.WriteLine("Base print");
        }
    }

    public class Derived1 : Base
    {
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Derived1 print");
        }
    }

    public class Derived2 : Derived1
    {
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Derived2 print");
        }
    }

    public sealed class Derived3 : Derived2
    {
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Derived3 print");
        }
    }
}
