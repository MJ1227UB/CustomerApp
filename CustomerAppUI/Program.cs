using System;
using System.Collections.Generic;
using CustomerAppBLL;
using CustomerAppEntity;

namespace CustomerAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();
        
        static void Main(string[] args)
        {
            bllFacade.CustomerService.Create(new Customer()
            {
                FirstName = "Bob",
                LastName = "Dylan",
                Adress = "BongoStreet 202"
            });
            bllFacade.CustomerService.Create(new Customer()
            {
                FirstName = "Lars",
                LastName = "Bilde",
                Adress = "Ostestrasse 202"
            });
            
            String[] menuItems =
            {
                "List All Customers",
                "Add Customer",
                "Delete Customer",
                "Edit Customer",
                "Exit",
            };

            //Show Menu
            //Wait for selection
            // - Show selection or
            // - Waring and go back

            var selection = 0;

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListCustomers();
                        break;
                    case 2:
                        AddCustomers();
                        break;
                    case 3:
                        DeleteCustomer();
                        break;
                    case 4:
                        EditCustomer();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");
            Console.ReadLine();
        }

        private static Customer FindCustomerByID()
        {
            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }

            return bllFacade.CustomerService.get(id);
        }

        private static void EditCustomer()
        {
            var customerFound = FindCustomerByID();
            if (customerFound != null)
            {
                Console.WriteLine("First Name: ");
                customerFound.FirstName = Console.ReadLine();
                Console.WriteLine("Last Name: ");
                customerFound.LastName = Console.ReadLine();
                Console.WriteLine("Adress: ");
                customerFound.Adress = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Customer not found!");
            }
        }

        private static void DeleteCustomer()
        {
            var customerFound = FindCustomerByID();
            if (customerFound != null)
            {
                bllFacade.CustomerService.Delete(customerFound.Id);
            }
            var response = customerFound == null ? "Customer not found" : "Customer was deleted";
            Console.WriteLine(response);
        }

        private static void AddCustomers()
        {
            Console.WriteLine("First Name:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Last Name:");
            var lastName = Console.ReadLine();

            Console.WriteLine("Adress:");
            var adress = Console.ReadLine();

            bllFacade.CustomerService.Create(new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Adress = adress
            });
        }

        private static void ListCustomers()
        {
            Console.WriteLine("\nList of Customers:");
            foreach (var customer in bllFacade.CustomerService.GetAll())
            {
                Console.WriteLine($"Id: {customer.Id} Name: {customer.FirstName} {customer.LastName} Adress: {customer.Adress}");
            }
            Console.WriteLine("");
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select what you want to do:\n");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}:{menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > 5)
            {
                Console.WriteLine("You need to select a number between 1-5");
            }

            Console.WriteLine($"Selection: {selection}");
            return selection;
        }
    }
}