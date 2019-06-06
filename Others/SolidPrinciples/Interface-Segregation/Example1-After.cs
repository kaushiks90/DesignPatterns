//Each class now has only properties that they need. Now we are upholding the Interface Segregation Principle!
//The ISP can potentially result in a lot of additional interfaces

using System;

namespace SolidPrinciples.Interface.Segregation.After
{
   
    public interface IProduct
    {
        int ID { get; set; }
        double Weight { get; set; }
        int Stock { get; set; }
    }
    public interface IPants
    {
        int Inseam { get; set; }
        int WaistSize { get; set; }
    }
    public interface IHat
    {
        int HatSize { get; set; }
    }
    public class Jeans : IProduct, IPants
    {
        public int ID { get; set; }
        public double Weight { get; set; }
        public int Stock { get; set; }
        public int Inseam { get; set; }
        public int WaistSize { get; set; }
    }

    public class BaseballCap : IProduct, IHat
    {
        public int ID { get; set; }
        public double Weight { get; set; }
        public int Stock { get; set; }
        public int HatSize { get; set; }
    }
   
}