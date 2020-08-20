using System;
using System.Collections.Generic;
using System.Linq;

namespace JurasicPark
{
    class Dino
    {
        // Name (string)
        public string Name { get; set; }

        // Diet Type:
        public string Diet { get; set; }

        // When added (Acquired) to the system: (date time data type)
        public DateTime WhenAcquired { get; set; } = DateTime.Now;

        // Weight: (int)
        public string Weight { get; set; }

        // Enclosure Number (that is holding dino): (int)
        public int EnclosureNumber { get; set; }

        // description for dino (string)
        public string Description()
        {
            var description = ($"{Name} is a {Diet} that we found {WhenAcquired}. Sitting at {Weight} lbs, you can see them in enclosure {EnclosureNumber}!");

            return description;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // PEDAC
            // 
            // Problem:
            // I need a program that I can hold a list of dinosours.
            //
            // CRUD
            // Create: Add new dino
            // Read: Get lists of dino that are housed in enclosures
            // Update: Update a transfer/switch of enclosure numbers
            // Delete : remove dino from list

            // Data: 
            // need a "Dino" class
            // need a list of the dinos

            // Algorithm:
            //
            // Welcome message?
            // 
            //
            // Show a menu of options
            //
            // make new dino input
            // see all current dinos and current enclosed number area
            // input name of dino and change(transfer) enclosed number area
            // summary of carnivor dinos (number)
            // summary of herb dinos (number)
            // remove dino from list (find and delete)
            // quit program
            var dinos = new List<Dino>(){
              new Dino {
                Name = "BroRex",
                Diet = "Herbivore",
                WhenAcquired = DateTime.Now,
                Weight = "653",
                EnclosureNumber = 3,
              },

              new Dino {
                Name = "Staggy",
                Diet = "Carnivore",
                WhenAcquired = DateTime.Now,
                Weight = "45621",
                EnclosureNumber = 1,
              },

               new Dino {
                Name = "Bettyaurus",
                Diet = "Herbivore",
                WhenAcquired = DateTime.Now,
                Weight = "750",
                EnclosureNumber = 2,
              },
            };


            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");
            Console.WriteLine("Hello World! Welcome to the Jurassic Park database");
            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");

            var quitApplication = false;
            while (quitApplication == false)
            {
                Console.WriteLine("What would you like to do today?");
                Console.WriteLine("ADD - Input new data on a new Dino");
                Console.WriteLine("VIEW - Look-up Dino data and where you can see them");
                Console.WriteLine("REMOVE - Delete a Dino from our database");
                Console.WriteLine("TRANSFER - Update Dino Enclosure number");
                Console.WriteLine("SUMMARY - Display a summary of specific Dino data");
                Console.WriteLine("QUIT - Exit the Dino database");
                Console.WriteLine();
                Console.Write("Choice: ");
                var choice = Console.ReadLine();

                if (choice.ToUpper() == "QUIT")
                {
                    quitApplication = true;
                }

                if (choice.ToUpper() == "ADD")
                {
                    Console.Write("Name: ");
                    var name = Console.ReadLine();

                    Console.Write("Diet (Carnivore or Herbivore): ");
                    var diet = Console.ReadLine();

                    var whenAcquired = DateTime.Now;
                    Console.WriteLine($"When added to database: {whenAcquired}");

                    Console.Write("Weight: ");
                    var weight = Console.ReadLine();

                    Console.Write("Enclosure Number: ");
                    var enclosureNumberString = Console.ReadLine();
                    var enclosurenumber = int.Parse(enclosureNumberString);

                    var dino = new Dino()
                    {
                        Name = name,
                        Diet = diet,
                        WhenAcquired = DateTime.Now,
                        Weight = weight,
                        EnclosureNumber = enclosurenumber,
                    };

                    dinos.Add(dino);

                }

                if (choice.ToUpper() == "VIEW")
                {
                    foreach (var dino in dinos)
                    {
                        Console.WriteLine(dino.Description());
                    }

                }

                if (choice.ToUpper() == "REMOVE")
                {
                    var foundDino = PromptAndFindDino(dinos);

                    if (foundDino != null)
                    {
                        Console.WriteLine(foundDino.Description());

                        Console.Write("Are you sure you want to delete a deceased Dino, YES or NO: ");
                        var answer = Console.ReadLine();

                        if (answer.ToUpper() == "YES")
                        {
                            dinos.Remove(foundDino);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"There is no Dino to delete");
                    }
                }

                if (choice.ToUpper() == "TRANSFER")
                {
                    var foundDino = PromptAndFindDino(dinos);

                    if (foundDino != null)
                    {
                        Console.WriteLine(foundDino.Description());

                        Console.Write("Are you sure you want to transfer this Dino, YES or NO: ");
                        var answer = Console.ReadLine();

                        if (answer.ToUpper() == "YES")
                        {
                            Console.Write("New Enclosure Number: ");
                            var newEnclosureNumber = Console.ReadLine();

                            foundDino.EnclosureNumber = int.Parse(newEnclosureNumber);

                        }
                        else
                        {
                            Console.WriteLine($"There is no Dino found");
                        }
                    }
                }

                if (choice.ToUpper() == "SUMMARY")
                {

                }

                Console.WriteLine("Have a great day!");

            }
        }

        static Dino PromptAndFindDino(List<Dino> dinosToSearchWithin)
        {
            Console.Write("Name: ");
            var nameOfDinoToSearch = Console.ReadLine();

            var foundDino = dinosToSearchWithin.FirstOrDefault(dino => dino.Name == nameOfDinoToSearch);
            return foundDino;
        }
    }
}