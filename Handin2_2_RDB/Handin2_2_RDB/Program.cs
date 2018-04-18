using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handin2_2_RDB.Classes;
using Handin2_2_RDB.Context;
using System.Configuration;
/*
 * Welcome to the PersonIndex of Group 13
 * By Daniel and Lisbeth
 */



namespace Handin2_2_RDB.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {


                using (var db = new PersonIndexContext())
                {
                    //Console.WriteLine("HANS mit em flammenwerfer"); //CRUCIAL DO NOT DELETE, IT WILL FUCK UP THE PROGRAM IF REMOVED
                    Operations OPS = new Operations();
                    int choice;

                    do
                    {
                        
                        //Tilføjet CRUD
                        Console.WriteLine("\nCRUD OPERATIONS\n--------------");
                        Console.WriteLine("1.Add new Contact");
                        Console.WriteLine("2.View Contacts");
                        Console.WriteLine("3.Update Contact Detail");
                        Console.WriteLine("4.Delete Contact");
                        Console.WriteLine("5.Exit \n");

                        choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                OPS.AddContact(db);
                                break;
                            case 2:
                                OPS.ViewContact(db);
                                break;
                            case 3:
                                OPS.UpdateContact(db);
                                break;
                            case 4:
                                OPS.DeleteContact(db);
                                break;
                        }
                    } while (choice != 5);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"enter valid choice: {e.Message}");
                Console.ReadKey();
            }
        }
    }
}

