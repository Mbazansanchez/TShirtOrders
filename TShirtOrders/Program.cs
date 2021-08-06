using System;
using System.Collections.Generic;

//Program.cs
//Programmer: Rob Garner (rgarner7@cnm.edu)
//Date: 10 Mar 2020
//Purpose: Process a series of tshirt orders. 
namespace TShirtOrders
{
    class Program
    {
        private const string CompanyName = "Super Shirt Ordermatic 3000";
        private const string CompanySlogan = "The best shirt ordering system in the multiverse!";

        static void Main(string[] args)
        {
            Header();
            char option;
            List<TShirtOrder> orders = new List<TShirtOrder>();
            do
            {
                DisplayShirtOrders(orders);
                string userInput = GetStringFromUser("(A)dd shirt (R)emove shirt (T)otal (E)xit: ");
                option = userInput.Trim().ToUpper()[0];
                switch (option)
                {
                    case 'A':
                        AddShirtOrder(orders);
                        break;
                    case 'R':
                        RemoveShirtOrder(orders);
                        break;
                    case 'T':
                        DisplayTotal(orders);
                        break;
                }
            } while (option != 'E');
            Console.WriteLine("Thank you for using " + CompanyName);
        }

        private static void DisplayTotal(List<TShirtOrder> orders)
        {
            decimal total = 0;
            foreach (var order in orders)
            {
                //private was set to 
                total = total + order.Price;
            }
            Console.WriteLine("Total price of order is: " + total);
        }

        private static void RemoveShirtOrder(List<TShirtOrder> orders)
        {
            int index = GetIntFromUser("Enter index of shirt order to remove: ");
            if (GetBoolFromUser("Are you sure you want to delete this order"))
            {
                //changed the Remove funtion to RemoveAt function to target the index and index properly.
                orders.RemoveAt(index);
            }
        }

        private static void AddShirtOrder(List<TShirtOrder> orders)
        {
            TShirtOrder order = new TShirtOrder();
            order.FirstName = GetStringFromUser("Please enter your first name: ");
            order.LastName = GetStringFromUser("Please enter your last name: ");
            order.IsLocalPickup = GetBoolFromUser("Local pickup");
            if (!order.IsLocalPickup)
            {
                order.Address = GetStringFromUser("Address: ");
            }
            //Get double will not work because printarea is a decimal in the contructor of the class.
            order.PrintAreaInSqIn = (decimal)GetDoubleFromUser("Please enter are of your design in square inches: ");
            order.NumColors = GetIntFromUser("Please enter number of colors: ");
            order.NumShirts = GetIntFromUser("Please enter the number of shirts: ");
            Console.WriteLine(order.ToString());
            orders.Add(order);
        }

        private static void DisplayShirtOrders(List<TShirtOrder> orders)
        {
            Console.WriteLine();
            Console.WriteLine("Current shirts orders:");
            //count does not need Paraenthese because its a value not a funtion.
            if (orders.Count > 0)
            {
                for (int i = 0; i < orders.Count; ++i)
                {
                    Console.WriteLine((i + 1) + ": " + orders[i]);
                }
            }
            else
            {
                Console.WriteLine("No shirts in order.");
            }
            Console.WriteLine();
        }

        private static void Header()
        {
            Console.WriteLine("Welcome to " + CompanyName + "!");
            Console.WriteLine(CompanySlogan);
            Console.WriteLine();
        }

        private static bool GetBoolFromUser(string prompt)
        {
            Console.Write(prompt + " (y/n)? ");
            return Console.ReadLine().ToLower()[0] == 'y';
        }

        private static int GetIntFromUser(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        private static double GetDoubleFromUser(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        private static string GetStringFromUser(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
