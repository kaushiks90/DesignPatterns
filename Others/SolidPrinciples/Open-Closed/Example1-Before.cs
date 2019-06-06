//Let's imagine a scenario in which we are given several Rectangles and need to calculate the total combined area of all of them. 
//We then come along and create a solution that looks something like this:

using System;
using System.Net.Mail;

namespace SolidPrinciples.Open.Closed.Principle.Before
{
   
   public class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }   


    public class CombinedAreaCalculator
    {
        public double Area (object[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                if(shape is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)shape;
                    area += rectangle.Width * rectangle.Height;
                }
            }
            return area;
        }
    }

    //The above code does excatly what we want ie calculate the area of Rectangle
    //What if we want to calculate the area of circle?
    public class Circle
    {
        public double Radius { get; set; }
    }
    //Now we want to change the CombinedAreaCalculator to accommodate this change
    public class CombinedAreaCalculatorChange
    {
        public double Area(object[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                if (shape is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)shape;
                    area += rectangle.Width * rectangle.Height;
                }
                if (shape is Circle)
                {
                    Circle circle = (Circle)shape;
                    area += (circle.Radius * circle.Radius) * Math.PI;
                }
            }
            return area;
        }
    }

}