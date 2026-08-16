using System;
using System.Collections.Generic;
using System.Text;

namespace Task09_InheritanceInterfaces
{
    public class Rectangle:Shape, IDrawable,IResizable
    {
        decimal width;
        decimal height;
        public Rectangle()
        {
            
        }
        public Rectangle(decimal width, decimal height)
        {
            this.width = width;
            this.height = height;
        }

        public override decimal CalculateArea()
        {
            return width * height;
        }

        public void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }

        public void Resize(double factor)
        {
             (height)*= (decimal)factor;
             (width)*= (decimal)factor;
        }
    }
}
