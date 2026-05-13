using System;
using System.IO;

// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 15;
string? readResult;
string menuSelection = "";
int petCount = 0;
string anotherPet = "y";
bool validEntry = false;
int petAge = 0;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "Dog";
            animalID = "d1";
            animalAge = "4";
            animalPhysicalDescription = "Large Rottweiler mix Husky female weighing about 17 Kilograms. Good House Hold Dog.";
            animalPersonalityDescription = "loves Jumping on people, gives lots of Love and like attention.";
            animalNickname = "Nova Lova, Loaf of bread";
            break;

        case 1:
            animalSpecies = "Dog";
            animalID = "d2";
            animalAge = "4";
            animalPhysicalDescription =  "Large Rottweiler mix Husky Male weighing about 20 Kilograms. Good House Hold Dog.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "Diesel, Big D, Big Dizzle";
            break;

        case 2:
            animalSpecies = "Cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "Small Tabby Kitten,Rubies Sister,Naughty,Likes food and to sleep, litter box trained.";
            animalPersonalityDescription = "friendly,mischievous, playful, and loves to snuggle.";
            animalNickname = "Bonnie, Bon Bon, Bonny Bannana,";
            break;

        case 3:
            animalSpecies = "Cat";
            animalID = "c4";
            animalAge = "1";
            animalPhysicalDescription = "Small Tabby Kitten,Bonnie Sister,Naughty,Likes food,Independent, litter box trained.";
            animalPersonalityDescription = "mischievous, playful,Loves to be stroked and played with but is also happy to entertain herself.";
            animalNickname = "Ruby, Rubarb balubarb, Rubes  ";
            break;

             case 4:
            animalSpecies = "Cat";
            animalID = "c5";
            animalAge = "";
            animalPhysicalDescription = "Big Tabby Cat,Likes food,Likes Bullying other cats.";
            animalPersonalityDescription = "Mischievous,Loves Scratching Couches, Likes his butt being slapped,Loves foods and sleeps a lot, a real hunter";
            animalNickname = "Harley, Hollie Hollie, Harley Pop, Harls";
            break;

        case 5:
            animalSpecies = "Cat";
            animalID = "c6";
            animalAge = "6";
            animalPhysicalDescription = "Medium-sized Black & White Tuxedo Cat.";
            animalPersonalityDescription = "Psychotic, Loves to attack you, Likes to be petted but only on her terms, Can be cute but sometimes wants to claw your eyes out.";
            animalNickname = "Spitfire, Spit Spit,Sparkles, Spaticus, spectacular.";
            break;

        case 6:
            animalSpecies = "Cat";
            animalID = "c7";
            animalAge = "10";
            animalPhysicalDescription = "Thin Ginger tabby cat. Likes to sleep in the bar,Can be found in the laundry room napping on the clean clothes.";
            animalPersonalityDescription = "Calm, Old cat , gets along with other cats if they dont bother him.";
            animalNickname = "Ferrari, Ferocious, Rarry Fur,";
            break;
        case 7:
            animalSpecies = "Cat";
            animalID = "c8";
            animalAge = "4";
            animalPhysicalDescription = "Medium-sized tabby cat with white paws and a white chest. Likes to sleep alot. Not Trained to use a litter box, ";
            animalPersonalityDescription = "Quiet , chilled cat, always on her own mission.";
            animalNickname = "Shelby, Shelby Baby";
            break;

        case 8:
            animalSpecies = "Cat";
            animalID = "c9";
            animalAge = "3";
            animalPhysicalDescription = "Very Large Russian Gray. White stripe down chest and white paws.";
            animalPersonalityDescription = "Very Shy Scaredy cat, Loves to hide under the bed, but is very sweet and loving when he comes out.";
            animalNickname = "Huey, Hue-Burt, Huey-Bear, Huey-Boo";
            break;



        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

// display the top-level menu options
do
{
    Console.Clear();

   Console.WriteLine("\t****Welcome to the Jones Animal Home.****\n");

   Console.WriteLine("\t\t****Main Menu****\n");
   Console.WriteLine("\t 1. List all of our current pet information.");
   Console.WriteLine("\t 2. Add a new animal friend.");
   Console.WriteLine("\t 3. Update animal's physical descriptions.");
   Console.WriteLine("\t 4. Update animal's personality descriptions.");
   Console.WriteLine("\t 5. Update an animal’s age.");
   Console.WriteLine("\t 6. Update an animal’s Nickname.");
   Console.WriteLine("\t 7. Display all cats with a specified characteristic.");
   Console.WriteLine("\t 8. Display all dogs with a specified characteristic.");
   Console.WriteLine();
   Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
        // NOTE: We could put a do statement around the menuSelection entry to ensure a valid entry, but we
        //  use a conditional statement below that only processes the valid entry values, so the do statement 
        //  is not required here. 
    }

    // use switch-case to process the selected menu option
    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j].ToString());
                    }
                }
            }
            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        case "2":
         
            anotherPet = "y";
            petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            while (anotherPet == "y" && petCount < maxPets)
            {
                // get species (cat or dog) - string animalSpecies is a required field 
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();
                    readResult = readResult?.ToLower();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            //Console.WriteLine($"You entered: {animalSpecies}.");
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                // get the pet's age. can be ? at initial entry.
                do
                {
                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult;
                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);


                // get a description of the pet's physical appearance - animalPhysicalDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }
                } while (validEntry == false);


                // get a description of the pet's personality - animalPersonalityDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }
                } while (validEntry == false);


                // get the pet's nickname. animalNickname can be blank.
                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }
                } while (validEntry == false);

                // store the pet information in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                // increment petCount (the array is zero-based, so we increment the counter after adding to the array)
                petCount = petCount + 1;

                // check maxPet limit
                if (petCount < maxPets)
                {
                    // another pet?
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }

                    } while (anotherPet != "y" && anotherPet != "n");
                }
                //NOTE: The value of anotherPet (either "y" or "n") is evaluated in the while statement expression - at the top of the while loop
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;

        case "3":
    Console.WriteLine("Enter the ID number of the animal whose physical description you want to update:");
    readResult = Console.ReadLine();

    for (int i = 0; i < maxPets; i++)
    {
        if (ourAnimals[i, 0] == $"ID #: {readResult}")
        {
            do
            {
                Console.WriteLine($"Enter a new physical description for {ourAnimals[i, 0]} (size, color, breed, gender, weight, housebroken)");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalPhysicalDescription = readResult.ToLower();
                    validEntry = !string.IsNullOrWhiteSpace(animalPhysicalDescription);
                }
            } while (validEntry == false);

            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            Console.WriteLine("Physical description updated successfully!");
            break;
        }
    }

    Console.WriteLine("Press any key to return to the main menu...");
    Console.ReadKey();
    break;


        

case "4":

    Console.WriteLine("Enter the ID number of the animal whose personality description you want to update:");
    readResult = Console.ReadLine();

    for (int i = 0; i < maxPets; i++)
    {
        if (ourAnimals[i, 0] == $"ID #: {readResult}")
        {
            do
            {
                Console.WriteLine($"Enter a new personality description for {ourAnimals[i, 0]}");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalPersonalityDescription = readResult;
                    validEntry = !string.IsNullOrWhiteSpace(animalPersonalityDescription);
                }
            } while (validEntry == false);

            ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
            Console.WriteLine("Personality description updated successfully!");
            break;
        }
    }
    Console.WriteLine("Press any key to return to the main menu...");
    Console.ReadKey();
    break;

case "5":
    Console.WriteLine("Enter the ID number of the animal whose age you want to update:");
    readResult = Console.ReadLine();

    for (int i = 0; i < maxPets; i++)
    {
        if (ourAnimals[i, 0] == $"ID #: {readResult}")
        {
            do
            {
                Console.WriteLine($"Enter the new age for {ourAnimals[i, 0]}");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalAge = readResult;
                    validEntry = int.TryParse(animalAge, out petAge);
                }
            } while (validEntry == false);

            ourAnimals[i, 2] = "Age: " + animalAge;
            Console.WriteLine("Age updated successfully!");
            break;
        }
    }

    Console.WriteLine("Press any key to return to the main menu...");
    Console.ReadKey();
    break;
    
   


        case "6":
    Console.WriteLine("Enter the ID number of the animal whose nickname you want to update:");
    readResult = Console.ReadLine();

    for (int i = 0; i < maxPets; i++)
    {
        if (ourAnimals[i, 0] == $"ID #: {readResult}")
        {
            do
            {
                Console.WriteLine($"Enter a new nickname for {ourAnimals[i, 0]}");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    animalNickname = readResult;
                    validEntry = !string.IsNullOrWhiteSpace(animalNickname);
                }
            } while (validEntry == false);

            ourAnimals[i, 1] = "Nickname: " + animalNickname;
            Console.WriteLine("Nickname updated successfully!");
            break;
        }
    }

    Console.WriteLine("Press any key to return to the main menu...");
    Console.ReadKey();
    break;

        case "7":
            // Display all cats with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "8":
            // Display all dogs with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit");
