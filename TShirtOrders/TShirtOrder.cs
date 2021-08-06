using System;
//TShirtOrder.cs
//Programmer: Michael Bazan (mbazansanchez@cnm.edu)
//Date: 
//Purpose: Model a TShirt order.
namespace TShirtOrders
{
    /// <summary>
    /// TShirtOrder
    /// Provides a model of a shirt order.
    /// </summary>
    public class TShirtOrder
    {
        private decimal printAreaInSqIn;
        private int numColors;
        private int numShirts;
        //printAreaInSqIn needs to have a default value set in the constructor. mbs
        public TShirtOrder(string firstName = "", string lastName = "", string address = "", bool isLocalPickup = true, decimal printAreaInSqIn = 1, int numberOfColors = 1, int numberOfShirts = 1)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            IsLocalPickup = isLocalPickup;
            this.printAreaInSqIn = printAreaInSqIn;
            //num colors and num shirts cannot be pointing to each other. names had to be changed to paramater names. mbs
            this.numColors = numberOfColors;
            this.numShirts = numberOfShirts;
            Calc();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public bool IsLocalPickup { get; set; }

        public decimal PrintAreaInSqIn
        {
            get { return printAreaInSqIn; }
            set { printAreaInSqIn = value; Calc(); }
        }


        public int NumColors
        {
            get { return NumColors; }
            set { NumColors = value; Calc(); }
        }

        public int NumShirts
        {
            get { return numShirts; }
            set { numShirts = value; Calc(); }
        }
        //get price is not supposed to be private.
        public decimal Price { get; set; }

        private void Calc()
        {
            this.Price = numShirts * (numColors * 2.25M + printAreaInSqIn * .05M);
        }

        //a class can not have the some name as a funtion unless it is an override funtion because it causes conflicts. mbs
        public string toString()
        {
            return FirstName + " "
                + LastName + " "
                + " Price: " + Price.ToString("c");
        }
    }
}
