using System;
using System.Collections.Generic;

class AddressPrompt
{
    AddressBook book;

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
       
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Main Menu");
        Console.WriteLine("****************************************");
        Console.WriteLine("A - Add a Contact");
        Console.WriteLine("D - Delete a Contact");
        Console.WriteLine("E - Edit a Contact");
        Console.WriteLine("L - List All Contact");
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
        string info = "";

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
                info = address + " " + email + " " + telephone;
                if (book.add(name, address, email, telephone))
                {
                    Console.WriteLine("Information successfully added!");
                }
                else
                {
                    Console.WriteLine("An address is already on file for {0}.", name);
                }
                break;
            case "D":
                Console.WriteLine("Enter Name to Delete: ");
                Console.WriteLine("Notice:both firstnameand lastname with a space between them");
                name = Console.ReadLine();
                if (book.remove(name))
                {
                    Console.WriteLine("Address successfully removed");
                }
                else
                {
                    Console.WriteLine("Address for {0} could not be found.", name);
                }
                break;
            case "L":
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
                    book.list((a) => Console.WriteLine("Name: {0} - Address: {1} - Email: {2} - Telephone: {3}", a.name, a.address, a.email,a.telephone));
                    Console.ResetColor();
                }
                break;
            case "E":
                Console.WriteLine("Enter Name to Edit: ");
                Console.WriteLine("Notice:both firstnameand lastname with a space between them");
                name = Console.ReadLine();
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