using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    class ProgramUI
    {
        private readonly DeveloperRepo developerRepo = new DeveloperRepo();
        private readonly DevTeamRepo devTeamRepo = new DevTeamRepo();

        //Method that runs/starts application
        public void Run()
        {
            //DeveloperList
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create new Developer:\n" +
                    "2. View All Developers:\n" +
                    "3. View Developers by name:\n" +
                    "4. Update Developer:\n" +
                    "5. Delete Developer:\n" +
                    "6. Exit");

                //Get User's input
                string input = Console.ReadLine();

                //Evaluate user's input and act accordingly
                switch (input)
                {
                    case "1":
                        CreateDeveloper();
                        break;
                    case "2":
                        //View Developer
                        DisplayDeveloper();
                        break;
                    case "3":
                        //View all Developers by Identifier
                        DisplayDeveloperByID();
                        break;
                    case "4":
                        //Update Developer
                        UpdateDeveloper();
                        break;
                    case "5":
                        //Delete Developer
                        DeleteDeveloper();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid ID");
                        break;

                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Developer Create
        public void CreateDeveloper()
        {
            Console.Clear();

            //Name
            Console.WriteLine("Enter the name of the Developer");
            string DeveloperName = Console.ReadLine();
            Developer name = new Developer();
            name.DeveloperName = DeveloperName;


            //ID
            Console.WriteLine("Enter the ID of the Developer");
            string devId = Console.ReadLine();
            int DevId = int.Parse(devId);
            name.DevID = DevId;
            //Has Access to Pluralsight
            Console.WriteLine("Does this Developer have access to Pluralsight? (y/n)");
            string HasAccessToPluralsight = Console.ReadLine();

            if (HasAccessToPluralsight == "y")
            {
                name.HasAccessToPluralsight = true;
            }
            else
            {
                name.HasAccessToPluralsight = false;
            }



            developerRepo.AddDeveloperToList(name);
        }

        //Developer Read
        public void DisplayDeveloper()
        {

        }

        //View Developer by ID
        public void DisplayDeveloperByID()
        {
            Console.Clear();
            List<Developer> developers = developerRepo.GetDeveloperList();

            foreach (Developer developer in developers)
            {
                Console.WriteLine($"Name: {developer.DeveloperName}\n" + $"ID: {developer.DevID}\n");
            }
        }

        //View Developers
        private void DisplayDeveloperByName()
        {
            Console.Clear();
            //Prompt the user to give me name
            Console.WriteLine("Enter the name of the Developer who you would like to see");

            //input
            string name = Console.ReadLine();

            //Find the Developer by the name
            Developer developer = developerRepo.GetDeveloperByName(name);

            //Display said Developer if it isn't null
            if (developer != null)
            {
                Console.WriteLine($"1. Name: {developer.DeveloperName}\n" +
                    $"2. ID: {developer.DevID}\n" +
                    $"3. Has Pluralsight: {developer.HasAccessToPluralsight}\n ");
            }
            else
            {
                Console.WriteLine("No developer by that name");
            }
        }

        //Developer Update
        private void UpdateDeveloper()
        {
            // Display all Developers
            DisplayDeveloper();

            //Ask for the ID of the Developer
            string oldDeveloper = Console.ReadLine();

            Console.Clear();
            Developer newDeveloper = new Developer();

            //Name
            Console.WriteLine("Enter the name of the Developer");
            newDeveloper.DeveloperName = Console.ReadLine();

            //ID
            Console.WriteLine("Enter the ID of the Developer");
            string devId = Console.ReadLine();
            object DevId = double.Parse(devId);

            //Has Access to Pluralsight
            Console.WriteLine("Does this Developer have access to Pluralsight? (y/n)");
            string HasAccessToPluralsight = Console.ReadLine();

            if (HasAccessToPluralsight == "y")
            {
                object hasAccessToPluralsight = true;
            }
            else
            {
                object hasAccessToPluralsight = false;
            }

            //DevId
            Console.WriteLine("Please enter a ID number for each Developer: \n" +
                "1. Richard Alimoh\n" +
                "2. Atif Baloch\n" +
                "3. Danielle Barrett\n" +
                "4. Michael Davidson\n" +
                "5. Jessica Klinck\n" +
                "6. Amel Mallem\n" +
                "7. Lukan Reibel\n" +
                "8. Charles Lucas\n");

            string idAsString = Console.ReadLine();
            int idAsInt = int.Parse(idAsString);
            newDeveloper.DevID = idAsInt;

            //Verify the update worked
            bool wasUpdated = developerRepo.UpdateExistingDeveloper(oldDeveloper, newDeveloper);

            if (wasUpdated)
            {
                Console.WriteLine("Content successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update content.");
            }

        }

        //Developer Delete
        private void DeleteDeveloper()
        {



            //Get the name they want to remove
            Console.WriteLine("Enter the name of the you want to remove:");

            string input = Console.ReadLine();

            //Call the delete method
            bool wasDeleted = developerRepo.RemoveDeveloperFromList(input);

            //If the Developer was deleted say so
            //Otherwise state it could not be deleted
            if (wasDeleted)
            {
                Console.WriteLine("The name was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The name could not be deleted.");
            }
        }
    }
}
