using System;
using System.Collections.Generic;

namespace Expense_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ch;
            List<Expense> expenses = new List<Expense>();

            do
            {
                Console.WriteLine("****************");
                Console.WriteLine("Expense Tracker");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View All Expenses");
                Console.WriteLine("3. View Total Expense");
                Console.WriteLine("4. Exit");
                Console.WriteLine("****************");

                try
                {
                    Console.Write("Enter Your Choice: ");
                    ch = Convert.ToInt32(Console.ReadLine());

                    switch (ch)
                    {
                        case 1:
                            try
                            {
                                Expense e = new Expense();
                                e.acc_details();
                                expenses.Add(e);

                                Console.WriteLine("Expense Added Successfully.");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Error: Please enter valid numeric values.");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                            finally
                            {
                                Console.WriteLine("Expense Processing Complete.");
                            }
                            break;

                        case 2:

                            if (expenses.Count == 0)
                            {
                                Console.WriteLine("No Expenses Found.");
                            }
                            else
                            {
                                Console.WriteLine("\nAll Expenses");

                                foreach (Expense e in expenses)
                                {
                                    e.disDet();
                                }
                            }

                            break;

                        case 3:

                            if (expenses.Count == 0)
                            {
                                Console.WriteLine("No Expenses Found.");
                            }
                            else
                            {
                                double total = 0;

                                foreach (Expense e in expenses)
                                {
                                    total += e.amt;
                                }

                                Console.WriteLine("Total Expense = Rs. " + total);
                            }

                            break;

                        case 4:

                            Console.WriteLine("Thank You for Using Expense Tracker.");
                            break;

                        default:

                            Console.WriteLine("Invalid Choice.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a valid menu choice.");
                    ch = 0;
                }

            } while (ch != 4);
        }

        class Expense
        {
            public int expID;
            public string category;
            public double amt;
            public string paymentmode;
            public DateTime expdate;

            public void acc_details()
            {
                Console.Write("Enter Expense ID: ");
                expID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Category: ");
                category = Console.ReadLine();

                Console.Write("Enter Amount: ");
                amt = Convert.ToDouble(Console.ReadLine());

                if (amt <= 0)
                {
                    throw new ArgumentException("Expense amount must be greater than zero.");
                }

                Console.Write("Enter Payment Mode (Cash/UPI/Card): ");
                paymentmode = Console.ReadLine();

                if (paymentmode.ToUpper() != "CASH" &&
                    paymentmode.ToUpper() != "UPI" &&
                    paymentmode.ToUpper() != "CARD")
                {
                    throw new ArgumentException("Invalid Payment Mode! Enter only Cash, UPI or Card.");
                }

                expdate = DateTime.Now;
            }

            public void disDet()
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Expense ID      : " + expID);
                Console.WriteLine("Category        : " + category);
                Console.WriteLine("Amount          : Rs. " + amt);
                Console.WriteLine("Payment Mode    : " + paymentmode);
                Console.WriteLine("Expense Date    : " + expdate);
                Console.WriteLine("-----------------------------");
            }
        }
    }
}