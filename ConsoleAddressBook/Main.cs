using System;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Security.Principal;
using static AddressPrompt;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


    class AddressPrompt
    {
        AddressBook book;
        public class ListBook
        {
            public string Name { get; set; }

            public string Email { get; set; }
            public string Address { get; set; }
            public string Telephone { get; set; }
        }


        public AddressPrompt()
        {
            book = new AddressBook();
        }

        static void Main(string[] args)
        {
            string selection = "";
            AddressPrompt prompt = new AddressPrompt();

            prompt.displayMenu();
            while (!selection.ToUpper().Equals("Q"))
            {
                Console.WriteLine("");
                Console.WriteLine("Please select a Selection or \"Q\" to Quit: ");
                selection = Console.ReadLine();
                prompt.performAction(selection);
            }
        }

        void displayMenu()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("****************************************");
            Console.WriteLine("**************  Main Menu  *************");
            Console.WriteLine("****************************************");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("A - Add a Contact");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("D - Delete a Contact");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("E - Edit a Contact");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("L - List All Contact");
            Console.ResetColor();
            Console.WriteLine("Q - Quit");
            Console.WriteLine("****************************************");
        }

        void performAction(string selection)
        {
            string firstname = "";
            string lastname = "";
            string name = "";
            string address = "";
            string email = "";
            string telephone = "";


            switch (selection.ToUpper())
            {
                case "A":

                    Console.WriteLine("Enter FirstName: ");
                    firstname = Console.ReadLine();
                    Console.WriteLine("Enter LastName: ");
                    lastname = Console.ReadLine();
                    name = firstname + " " + lastname;
                    Console.WriteLine("Enter Address: ");
                    address = Console.ReadLine();
                    Console.WriteLine("Enter Email: ");
                    email = Console.ReadLine();
                    Console.WriteLine("Enter telephone Number: ");
                    telephone = Console.ReadLine();

                    if (book.add(name, address, email, telephone))
                    {
                        Console.WriteLine("Information successfully added!");
                        ListBook listBook = new ListBook
                        {
                            Name = name,
                            Address = address,
                            Email = email,
                            Telephone = telephone
                        };
                        ///string jsonData = System.IO.File.ReadAllText(@"C:\Users\maxnf\Desktop\C sharp clone\ConsoleAddressBook\jsconfig1.json");
                        ///List<ListBook> listBooks = new List<ListBook>();
                        ///List<ListBook> realList = JsonConvert.DeserializeObject<List<ListBook>>(jsonData);
                        ///listBooks.AddRange(realList);

                        string json = JsonConvert.SerializeObject(listBook, Formatting.Indented);

                        File.WriteAllText(@"C:\Users\maxnf\Desktop\C sharp clone\ConsoleAddressBook\jsconfig1.json", json);
                    }
                    else
                    {
                        Console.WriteLine("An address is already on file for {0}.", name);
                    }

                    break;
                case "D":
                    Console.WriteLine("Do you really want to delete this contact?(Y/N)");
                    string m = Console.ReadLine();

                    if (m == "Y" || m == "y")
                    {


                        Console.Clear();
                        Console.WriteLine("Enter Name to Delete: ");
                        Console.WriteLine("Notice:both firstnameand lastname with a space between them");
                        firstname = Console.ReadLine();
                        if (book.remove(name))
                        {
                            Console.WriteLine("Address successfully removed");
                        }
                        else
                        {
                            Console.WriteLine("Address for {0} could not be found.", firstname + " " + lastname);
                        }
                    }
                    break;
                case "L":

                    Console.Clear();
                    if (book.isEmpty())
                    {
                        Console.WriteLine("There are no entries.");
                    }
                    else
                    {

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Addresses:");
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        Console.WriteLine("{0,-25} {1,5} {2,25} {3,40}", "Name", "Address", "Email", "Telephone");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        book.list((a) => Console.WriteLine("{0,-25} {1,5} {2,20} {3,30}", a.name, a.address, a.email, a.telephone));
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        Console.ResetColor();
                    }

                    break;
                case "E":

                    Console.WriteLine("Enter Name to Edit: ");
                    Console.WriteLine("Notice:both firstnameand lastname with a space between them");
                    firstname = Console.ReadLine();
                    Address addr = book.find(name);
                    if (addr == null)
                    {
                        Console.WriteLine("Address for {0} count not be found.", name);

                    }
                    else
                    {
                        Console.WriteLine("Enter new Address: ");
                        addr.address = Console.ReadLine();
                        Console.WriteLine("Address updated for {0}", name);

                    }
                    break;
            }
        }
    }
