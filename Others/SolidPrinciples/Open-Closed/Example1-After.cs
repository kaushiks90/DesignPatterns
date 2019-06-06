using System;
using System.Net.Mail;

namespace SolidPrinciples.Open.Closed.Principle.After
{
  
    public abstract class Shape
    {
        public abstract double Area();
    }

    public class Rectangle: Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override double Area()
        {
            return Width * Height;
        }
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double Area()
        {
            return Radius * Radius * Math.PI;
        }
    }
    public class CombinedAreaCalculator
    {
        public double Area (Shape[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                area += shape.Area();              
            }
            return area;
        }
    }   
}