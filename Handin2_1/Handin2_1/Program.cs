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
            obj2.number = 55;
            obj3.city = "Adolfslund";


            Console.WriteLine($"Navn: {obj1.firstName} \nNummer: {obj2.number} \nBy: {obj3.city}");
        }
    }

}
