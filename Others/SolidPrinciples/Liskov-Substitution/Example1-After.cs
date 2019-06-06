using System;

namespace SolidPrinciples.Liskov.Substitution.After
{
    internal class Program
    {

        private static void Main()
        {

        }

    }
    //We'll use the classic Circle-Ellipse problem to demonstrate this principle. 
    //Let's imagine that we need to find the area of any ellipse. 
    //So, we create a class that represents an ellipse:

    public class Ellipse
    {
        public double MajorAxis { get; set; }
        public double MinorAxis { get; set; }

        public virtual void SetMajorAxis(double majorAxis)
        {
            MajorAxis = majorAxis;
        }
        public virtual void SetMinorAxis(double minorAxis)
        {
            MajorAxis = minorAxis;
        }
        public virtual double Area()
        {
            return MajorAxis * MinorAxis * Math.PI;
        }
    }

    //We know from high school geometry that a circle is just a special case for an ellipse, 
    //so we create a Circle class that inherits from Ellipse, 
    // but SetMajorAxis sets both axes
    //(because in a circle, the major and minor axes must always be the same, 
    //which is just the radius) :

    //public class Circle : Ellipse
    //{
    //    public override void SetMajorAxis(double majorAxis)
    //    {
    //        base.SetMajorAxis(majorAxis);
    //        this.MinorAxis = majorAxis; //In a cirle, each axis is identical
    //    }
    //}

    //public class Result
    //{
    //    public void Method1()
    //    {
    //        Circle circle = new Circle();
    //        circle.SetMajorAxis(5);
    //        circle.SetMinorAxis(4);
    //        var area = circle.Area(); //5*4 = 20, but we expected 5*5 = 25
    //    }
    //}



    //This is a violation of the Liskov Substitution Principle.However, 
    //the best way to refactor this code is not obvious, as there are quite a few possibilities. 
    //One solution might be to have Circle implement SetMinorAxis as well:
    public class Circle : Ellipse
    {
        public override void SetMajorAxis(double majorAxis)
        {
            base.SetMajorAxis(majorAxis);
            this.MinorAxis = majorAxis; //In a cirle, each axis is identical
        }

        public override void SetMinorAxis(double minorAxis)
        {
            base.SetMinorAxis(minorAxis);
            this.MajorAxis = minorAxis;
        }

        public override double Area()
        {
            return base.Area();
        }
    }
    //Another solution, one with less code overall, might be to treat Circle as an entirely separate class:
    public class Circle1
    {
        public double Radius { get; set; }
        public void SetRadius(double radius)
        {
            this.Radius = radius;
        }

        public double Area()
        {
            return this.Radius * this.Radius * Math.PI;
        }
    }
}