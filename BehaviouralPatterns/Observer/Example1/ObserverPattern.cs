using System;
using System.Collections.Generic;
using System.Text;

namespace EventsDelegates.ObserverPattern.Example1
{
    class ObserverPattern
    {
        private static void MainMethod()
        {

            Carrots carrots = new Carrots(0.82);
            carrots.Attach(new Restaurant("Mackay's", 0.77));
            carrots.Attach(new Restaurant("Johnny's Sports Bar", 0.74));
            carrots.Attach(new Restaurant("Salad Kingdom", 0.75));

            // Fluctuating carrot prices will notify subscribing restaurants.
            carrots.PricePerPound = 0.79;
            carrots.PricePerPound = 0.76;
            carrots.PricePerPound = 0.74;
            carrots.PricePerPound = 0.81;
            Console.ReadLine();
        }
    }

    //Subject
    abstract class Veggies
    {
        private double _pricePerPound;
        public double PricePerPound
        {
            get { return _pricePerPound; }
            set
            {
                if (_pricePerPound != value)
                {
                    _pricePerPound = value;
                    Notify();
                }
            }
        }
        private List<IRestaurant> _retaurants = new List<IRestaurant>();
        public Veggies(double pricePerPound)
        {
            _pricePerPound = pricePerPound;
        }
        public void Attach(IRestaurant restaurant)
        {
            _retaurants.Add(restaurant);
        }
        public void Detach(IRestaurant restaurant)
        {
            _retaurants.Remove(restaurant);
        }
        public void Notify()
        {
            foreach (IRestaurant restaurant in _retaurants)
            {
                restaurant.Update(this);
            }
        }

    }
    //Concrete Subject
    class Carrots : Veggies
    {
        public Carrots(double price) : base(price)
        {

        }
    }
    //Observer 
    interface IRestaurant
    {
        void Update(Veggies veggies);
    }

    //Concrete observer
    class Restaurant : IRestaurant
    {
        private string _name;
        private Veggies _veggie;
        private double _purchaseThreshold;
        public Restaurant(string name, double purchaseThreshold)
        {
            _name = name;
            _purchaseThreshold = purchaseThreshold;
        }

        public void Update(Veggies veggie)
        {
            Console.WriteLine("Notified {0} of {1}'s " + " price change to {2:C} per pound.", _name, veggie.GetType().Name, veggie.PricePerPound);
            if (veggie.PricePerPound < _purchaseThreshold)
            {
                Console.WriteLine(_name + " wants to buy some " + veggie.GetType().Name + "!");
            }
        }
    }



}
