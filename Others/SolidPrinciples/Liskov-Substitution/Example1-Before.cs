//We'll use the classic Circle-Ellipse problem to demonstrate this principle.
//Let's imagine that we need to find the area of any ellipse. 
//So, we create a class that represents an ellipse:

using System;
using System.Net.Mail;

namespace SolidPrinciples.Liskov.Substitution.Before
{
  
    //We'll use the classic Circle-Ellipse problem to demonstrate this principle. 
    //Let's imagine that we need to find the area of any ellipse. 
    //So, we create a class that represents an ellipse:

    public class Ellipse
    {
        public double MajorAxis { get; set; }
        public double MinorAxis { get; set; }

        public virtual void SetMajorAxis(double majorAxis)
        {
            this.MajorAxis = majorAxis;
        }
        public virtual void SetMinorAxis(double minorAxis)
        {
            this.MajorAxis = minorAxis;
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

    public class Circle : Ellipse
    {
        public override void SetMajorAxis(double majorAxis)
        {
            base.SetMajorAxis(majorAxis);
            this.MinorAxis = majorAxis; //In a cirle, each axis is identical
        }
    }
    //See the problem now? 
    //If we set both axes, attempting to calculate the area gives the wrong result.
    public class Result
    {
        public void Method1()
        {
            Circle circle = new Circle();
            circle.SetMajorAxis(5);
            circle.SetMinorAxis(4);
            var area = circle.Area(); //5*4 = 20, but we expected 5*5 = 25
        }
    }
}