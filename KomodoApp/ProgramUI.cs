using KomodoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoApp
{
    class ProgramUI
    {

        private readonly DevelopersRepository _DeveloperRepo = new DevelopersRepository();
        private readonly DevelopersTeamsRepository _DevTeamRepo = new DevelopersTeamsRepository ();
        public void Run()
        {
            SeedDevList();
            Menu();
        }


        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {//display
                Console.WriteLine("What would you like to do?\n" +
                    "1. Add a new Developer\n" +
                    "2. View current Developers\n" +
                    "3. View by ID\n" +
                    "4. Update a Developer\n" +
                    "5. Delete a Developer\n" +
                    "6. Build a Developer Team\n" +
                    "7. View all Developer Teams\n" +
                    "8. View Team by ID\n" +
                    "9. Update a Developer Team\n" +
                    "10. Delete a team\n" +
                    "11. Add a Developer to a Team\n" +
                    "12. Remove a Devloper from a Team\n" +
                    "13. Close Application");
                //input from user
                string input = Console.ReadLine();
                //act from input
                switch (input)
                {
                    case "1":

                        addNewDevs();
                        break;
                    case "2":

                        displayAllDevs();
                        break;
                    case "3":

                        displayDevsByID();
                        break;
                    case "4":

                        updateExistingDevs();
                        break;
                    case "5":

                        deleteExistingDevs();
                        break;
                    case "6":

                        addNewDevsTeam();
                        break;
                    case "7":

                        displayAllDevsTeams();
                        break;
                    case "8":

                        displayDevsTeamsByID();
                        break;
                    case "9":

                        updateExistingDevsTeams();
                        break;
                    case "10":

                        deleteExistingDevsTeams();
                        break;
                    case "11":

                        addNewDevsTeamsMembers();
                        break;
                    case "12":

                        removeDevsTeamsMembers();
                        break;
                    case "13":

                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void addNewDevs()
        {
            Console.Clear();
            Developers newDevs = new Developers();

            Console.WriteLine("Developer Name");
            newDevs.Name = Console.ReadLine();

            Console.WriteLine("Enter New Developer ID");
            newDevs.IDNumber = Console.ReadLine();

            Console.WriteLine("Does this Developer have PluralSight access? Y/N");
            string hasAccessString = Console.ReadLine().ToLower();

            if (hasAccessString == "y")
            {
                newDevs.HasPluralSightAccess = true;
            }
            else
            {
                newDevs.HasPluralSightAccess = false;
            }
            _DeveloperRepo.AddDeveloperToList(newDevs);
        }
        private void displayAllDevs()
        {
            Console.Clear();

            List<Developers> developerDirectory = _DeveloperRepo.GetDeveloperList();

            foreach (Developers developer in developerDirectory)
            {
                Console.WriteLine($"Name: {developer.Name},\n" +
                    $" ID Number: {developer.IDNumber}\n" +
                    $" PluralSight: {developer.HasPluralSightAccess}");
            }
        }
        private void displayDevsByID()
        {
            Console.Clear();

            Console.WriteLine("Enter the unique ID of the Developer you'd like to see:");

            string iD = Console.ReadLine();

            Developers developer = _DeveloperRepo.GetDeveloperByID(iD);

            if (developer != null)
            {
                Console.WriteLine($"Name: {developer.Name},\n" +
                    $"ID Number: {developer.IDNumber}\n" +
                    $"PluralSight Access: {developer.HasPluralSightAccess}");
            }
            else
            {
                Console.WriteLine("No Developer by that ID.");
            }
        }

        private void DisplayDevTeamsByID()
        {
            Console.Clear();

            Console.WriteLine("Enter the unique ID of the Developer Team you'd like to see:");

            int iD = Convert.ToInt32(Console.ReadLine()); 

           DevelopersTeams devTeam = _DevTeamRepo.getDeveloperTeamsByID(iD);

            if (devTeam != null)
            {
                Console.WriteLine($"Name: {devTeam.TeamName},\n" +
                    $" ID Number: {devTeam.TeamID}\n");
                foreach (Developers dev in devTeam.DevTeamMembers)
                {
                    Console.WriteLine($"{dev.Name}, {dev.IDNumber}\n");
                }
            }
            else
            {
                Console.WriteLine("No Developer Team by that ID.");
            }
        }
        private void updateExistingDevs()
        {
            Console.Clear();

            displayAllDevs();

            Console.WriteLine("\nEnter the ID of the Developer you'd like to update:");

            //Get that Name
            string oldID = Console.ReadLine();

            //Build a new object
            Developers newDev = new Developers();

            //Name
            Console.WriteLine("Enter the name of the Developer:");
            newDev.Name = Console.ReadLine();

            //ID Number
            Console.WriteLine("Enter the ID number for the Developer:");
            newDev.IDNumber = Console.ReadLine();

            //HasAccess
            Console.WriteLine("Does this Developer currently have access to PluralSight? Y/N");
            string hasAccessString = Console.ReadLine().ToLower();

            if (hasAccessString == "y")
            {
                newDev.HasPluralSightAccess = true;
            }
            else
            {
                newDev.HasPluralSightAccess = false;
            }

            //Verify update worked
            bool updateWorked = _DeveloperRepo.UpdateExistingDeveloper(oldID, newDev);

            if (updateWorked)
            {
                Console.WriteLine("Developer succesfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Developer.");
            }

        }
        private void deleteExistingDevs()
        {
            displayAllDevs();

            Console.WriteLine("\nEnter the  ID of the Developer you'd like to remove");

            string input = Console.ReadLine();

           
            bool wasDeleted = _DeveloperRepo.RemoveDeveloperFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The Developer could not be deleted.");
            }
        }
        private void addNewDevsTeam()
        {
            Console.Clear();
            DevelopersTeams newDevTeam = new DevelopersTeams();
            
            //Name
            Console.WriteLine("Enter the name of the Developer Team:");
            newDevTeam.TeamName = Console.ReadLine();

            //ID Number
            Console.WriteLine("Enter the ID number for the Developer Team:");
            newDevTeam.TeamID = Convert.ToInt32(Console.ReadLine());

            //Add to Team List
            displayAllDevs();
            Console.WriteLine("Please enter the ID number of the Developer you'd like to add to this team.");

            string responseID = Console.ReadLine();
            Developers developer = _DeveloperRepo.GetDeveloperByID(responseID);
            newDevTeam.DevTeamMembers.Add(developer);

            _DevTeamRepo.AddDevsTeamToList(newDevTeam);
        }
        private void displayAllDevsTeams()
        {
            Console.Clear();

            List<DevelopersTeams> listOfTeams = _DevTeamRepo.GetDevTeamsList();

            foreach (DevelopersTeams devTeam in listOfTeams)
            {
                /*Console.WriteLine($"Name: {devTeam.TeamName},\n" +
                    $" ID Number: {devTeam.TeamID}\n" +
                    $" Members: {devTeam.DevTeamMembers}");*/

                Console.WriteLine($"Name: {devTeam.TeamName},\n" +
                    $" ID Number: {devTeam.TeamID}\n");
                foreach (Developers dev in devTeam.DevTeamMembers)
                {
                    Console.WriteLine($"{dev.Name}, {dev.IDNumber}\n");
                }
            }
        }
        private void displayDevsTeamsByID()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID of the Developer Team you'd like to see:");

            int iD = Convert.ToInt32(Console.ReadLine());

            DevelopersTeams devTeam = _DevTeamRepo.getDeveloperTeamsByID(iD);

            if (devTeam != null)
            {
                Console.WriteLine($"Name: {devTeam.TeamName},\n" +
                    $" ID Number: {devTeam.TeamID}\n");
                foreach (Developers dev in devTeam.DevTeamMembers)
                {
                    Console.WriteLine($"{dev.Name}, {dev.IDNumber}\n");
                }
            }
            else
            {
                Console.WriteLine("No Developer Team by that ID.");
            }
        }

        private void updateExistingDevsTeams()
        {
            Console.Clear();

            displayAllDevsTeams();

            Console.WriteLine("\nEnter the  ID of the Developer Team you'd like to update:");

            //Get that Name
            int oldID = Convert.ToInt32(Console.ReadLine());

            //Build a new object
            DevelopersTeams newDevTeam = new DevelopersTeams();

            //Name
            Console.WriteLine("Enter the name of the Developer Team:");
            newDevTeam.TeamName = Console.ReadLine();

            //ID Number
            Console.WriteLine("Enter the ID number for the Developer Team:");
            newDevTeam.TeamID = Convert.ToInt32(Console.ReadLine());

            //Current Team Members
            displayAllDevs();
            Console.WriteLine("Please enter the ID number of the Developer you'd like to assign as the new Team Lead.");

            string responseID = Console.ReadLine();
            Developers developer = _DeveloperRepo.GetDeveloperByID(responseID);
            newDevTeam.DevTeamMembers.Add(developer);

            //Verify update worked
            bool updateWorked = _DevTeamRepo.updateExistingDevsTeams(oldID, newDevTeam);

            if (updateWorked)
            {
                Console.WriteLine("Develop Team succesfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Developer Team.");
            }
        }
        private void deleteExistingDevsTeams()
        {
            displayAllDevs();

            Console.WriteLine("\nEnter the ID of the Developer Team you'd like to remove");

            int input = Convert.ToInt32(Console.ReadLine());

            //Call the Delete Method
            bool wasDeleted = _DevTeamRepo.RemoveDevTeamFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Developer Team was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The Developer Team could not be deleted.");
            }


        }
        private void addNewDevsTeamsMembers()
        {

            Console.Clear();

            displayAllDevsTeams();

            Console.WriteLine("\nEnter the ID of the Developer Team you'd like to add a member to:");

            //Get that Name
            int oldID = Convert.ToInt32(Console.ReadLine());

            //Call Object
            DevelopersTeams newDevTeam = _DevTeamRepo.getDeveloperTeamsByID(oldID);

            //Current Team Members
            displayAllDevs();
            Console.WriteLine("Please enter the ID number of the Developer you'd like to add.");

            string responseID = Console.ReadLine();
            Developers developer = _DeveloperRepo.GetDeveloperByID(responseID);
            newDevTeam.DevTeamMembers.Add(developer);

            //Verify update worked
            bool updateWorked = _DevTeamRepo.updateExistingDevsTeams(oldID, newDevTeam);

            if (updateWorked)
            {
                Console.WriteLine("Developer Team succesfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Developer Team.");
            }
        }
        private void removeDevsTeamsMembers()
        {
            Console.Clear();

            displayAllDevsTeams();

            Console.WriteLine("\nEnter the ID of the DevTeam you'd like to remove a member from:");

            //Get that Name
            int oldID = Convert.ToInt32(Console.ReadLine());

            //Call Object
            DevelopersTeams newDevTeam = _DevTeamRepo.getDeveloperTeamsByID(oldID);

            //Current Team Members
            displayAllDevs();
            Console.WriteLine("Please enter the ID number of the Developer you'd like to remove.");

            string responseID = Console.ReadLine();
            Developers developer = _DeveloperRepo.GetDeveloperByID(responseID);
            newDevTeam.DevTeamMembers.Remove(developer);

            //Verify update worked
            bool updateWorked = _DevTeamRepo.updateExistingDevsTeams(oldID, newDevTeam);

            if (updateWorked)
            {
                Console.WriteLine("Developer Team succesfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Develope Team.");
            }
        }

        private void SeedDevList()
        {
            Developers john = new Developers("John Pheobus", "1", true);
            Developers jack = new Developers("Jack George", "2", false);
            Developers andrea = new Developers("Andrea Gold", "3", true);
            Developers Emily = new Developers("Emily White", "4", true);
            Developers Shelia = new Developers("Shelia Vermillion", "5", true);

            _DeveloperRepo.AddDeveloperToList(Shelia);
            _DeveloperRepo.AddDeveloperToList(jack);
            _DeveloperRepo.AddDeveloperToList(Emily);
            _DeveloperRepo.AddDeveloperToList(andrea);
            _DeveloperRepo.AddDeveloperToList(john);
        }
    }
}
