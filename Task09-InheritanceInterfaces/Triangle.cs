using System;
using System.Collections.Generic;
using System.Text;

namespace Task09_InheritanceInterfaces
{
    public class Triangle : Shape ,IDrawable,IResizable
    {
        decimal base1;
        decimal height;
        decimal c = 1/2m;
        public Triangle()
        {
            
        }
        public Triangle(decimal base1, decimal height)
        {
            this.base1 = base1;
            this.height = height;
        }

        public override decimal CalculateArea()
        {
            return c * base1 * height;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing Tringle");
        }

        public void Resize(double factor)
        {
            base1*=(decimal)factor;
            height*=(decimal)factor;
        }
    }
}
