using System;
using System.Collections.Generic;
using System.Text;

namespace Task09_InheritanceInterfaces
{
    public class Circle : Shape, IDrawable,IResizable
    {
        decimal R;
        public Circle()
        {
            
        }
        public Circle(decimal r)
        {
            R = r;
        }

        public override decimal CalculateArea()
        {

            return (R * R) * (decimal)Math.PI;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing Circle");
        }

        public void Resize(double factor)
        {
            R *= (decimal)factor;
        }
    }
}
