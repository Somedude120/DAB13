using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ideen med POCO klasser er at de er simple datastrukturer som ikke har nogen form for tilknytning til hinanden
//Derfor viser jeg her de 3 klasser + main at klasserne er bygget og senere hen skal handin 2 tilknyttes
//Til hinanden så systemet faktisk giver mening.

namespace Handin2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiering af de forskellige POCO klasser.
            Person obj1 = new Person();
            Telephone obj2 = new Telephone();
            Adresse obj3 = new Adresse();

            obj1.firstName = "Hans";
            obj2.number = 200;
            obj2.homenumber = new List<int>(); //Tilføjer en ny liste.
            obj2.homenumber.Add(obj2.number); //Tilføjer nummer
            obj3.city = "Adolfslund";


            Console.WriteLine($"Navn: {obj1.firstName} \nNummer: {obj2.homenumber[0]} \nBy: {obj3.city}");
        }
    }

}
