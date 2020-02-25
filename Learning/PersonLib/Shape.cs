using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class Shape
    {
        public double Height;
        public double Width;
        public double Area;
    }

    public class Rectangle : Shape
    {
        public Rectangle(double h, double w)
        {
            this.Height = h;
            this.Width = w;
            this.Area = h * w;
        }
    }
    public class Square : Shape
    {
        public Square(double h)
        {
            this.Height = h;
            this.Width = h;
            this.Area = Math.Pow(h, 2);
        }
    }
    public class Circle : Shape
    {
        public Circle(double r)
        {
            this.Height = r;
            this.Width = r;
            this.Area = Math.Pow(r, 2) * Math.PI;
        }
    }
}
