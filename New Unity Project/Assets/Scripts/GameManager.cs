using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text;
using System.IO;

public class GameManager : MonoBehaviour {
    // Name of the external .txt file to be read in
    public string fileName = "Assets/Texts/Dialog.txt";
    // Number of days (used to calculate dialogues List<List<string>>)
    public const int days = 13;
    public static int currDay = 1;
    public static int prevDay = 0;

    // Will be used to store the instances of all animals currently existing within the day
    private List<GameObject> currentAnimals = new List<GameObject>();

    // Used as input for prefab models
    public GameObject player;
    public GameObject pig;
    public GameObject human;
    public GameObject horse;
    public GameObject donkey;
    public GameObject raven;
    public GameObject goat;
    public GameObject dog;
    public GameObject hen;
    public GameObject cow;
    public GameObject cat;

    // Will be used to store objects to reference them when creating instances
    private static Dictionary<string, GameObject> animals = new Dictionary<string, GameObject>();


    // Reads in external .txt file and parses by line
    private List<string> entries = new List<string>();
    // Further parses entries by first hex digit appearing in each line
    private List<List<string>> dialogues = new List<List<string>>();

    private Speak s1, s2;

    // Use this for initialization
    void Start()
    {
        // Fills out dictionary
        animals["player"] = player;
        animals["pig"] = pig;
        animals["human"] = human;
        animals["horse"] = horse;
        animals["donkey"] = donkey;
        animals["raven"] = raven;
        animals["goat"] = goat;
        animals["dog;"] = dog;
        animals["hen"] = hen;
        animals["cow"] = cow;
        animals["cat"] = cat;

        Debug.Log("COW: " + animals["cow"]);

        // Add a new dialog for each day - 13 days in total, days can be changed later
        for (int i = 0; i < days; i++)
        {
            dialogues.Add(new List<string>());
        }
        // If the dialogue loaded, parse it through to the dialogues List based on hexadecimal integers
        if (Load())
        {
            for (int i = 0; i < entries.Count; i++)
            {
                switch(entries[i].ToString().Substring(0, 1))
                {
                    case "1":
                        dialogues[0].Add(entries[i].ToString().Substring(2, entries[i].Length - 2));
                        break;
                    case "2":
                        dialogues[1].Add(entries[i].ToString().Substring(2, entries[i].Length - 2));
                        break;
                    case "3":
                        dialogues[2].Add(entries[i].ToString().Substring(2, entries[i].Length - 2));
                        break;
                    case "4":
                        dialogues[3].Add(entries[i].ToString().Substring(2, entries[i].Length - 2));
                        break;
                    case "5":
                        dialogues[4].Add(entries[i].ToString().Substring(2, entries[i].Length - 2));
                        break;
                    case "6":
                        dialogues[5].Add(entries[i].ToString().Substring(2, entries[i].Length - 2));
                        break;
                    case "7":
                        dialogues[6].Add(entries[i].ToString().Substring(2, entries[i].Length - 2));
                        break;
                    case "8":
                        dialogues[7].Add(entries[i].ToString().Substring(2, entries[i].Length - 2));
                        break;
                    case "9":
                        dialogues[8].Add(entries[i].ToString().Substring(2, entries[i].Length - 2));
                        break;
                    case "A":
                        dialogues[9].Add(entries[i].ToString().Substring(2, entries[i].Length - 2));
                        break;
                    case "B":
                        dialogues[10].Add(entries[i].ToString().Substring(2, entries[i].Length - 2));
                        break;
                    case "C":
                        dialogues[11].Add(entries[i].ToString().Substring(2, entries[i].Length - 2));
                        break;
                    case "D":
                        dialogues[12].Add(entries[i].ToString().Substring(2, entries[i].Length - 2));
                        break;
                    default:
                        Debug.Log("Index range out of ");
                        break;
                }
            }

            // DEBUG LOG - DELETE LATER
            for(int i = 0; i < dialogues.Count; i++)
            {
                for (int j = 0; j < dialogues[i].Count; j++)
                {
                    Debug.Log(dialogues[i][j].ToString());
                }

            }
        }
        else
        {
            Debug.Log("Fatal error in File IO: GameManager->Load()");
        }
    }

    // Update is called once per frame
    void Update ()
    {
        // If a new day occurs, delete all instances of animals, clear the list, create new instances of animals, and progress the prevDay to the currDay
        if(prevDay != currDay)
        {
            if (currentAnimals.Count > 0)
            {
                int numAnimals = currentAnimals.Count;
                for (int i = 0; i < numAnimals; i++)
                {
                    Destroy(currentAnimals[i]);
                }
                currentAnimals.Clear();
            }

            // Adds animals to the currentAnimals() list, signifying which animals and how many will be created
            addAnimals();

            for(int i = 0; i < currentAnimals.Count; i++)
            {
                Instantiate(currentAnimals[i], new Vector3(0, 0, 0), Quaternion.identity);
            }

            // Adds dialog to animals during specific days
            assignDialog();

            prevDay = currDay;
        }
    }

    bool Load()
    {
        // Handle any problems that might arise when reading the text
        try
        {
            string line;
            // Create a new StreamReader
            StreamReader theReader = new StreamReader(fileName, Encoding.Default);
            // Immediately clean up the reader after this block of code is done.
            // You generally use the "using" statement for potentially memory-intensive objects
            // instead of relying on garbage collection.
            using (theReader)
            {
                do
                {
                    line = theReader.ReadLine();

                    if (line != null)
                    {
                        entries.Add(line);
                    }
                }
                while (line != null);
                theReader.Close();
                return true;
            }
        }
        // Catch exceptions
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return false;
        }
    }

    void addAnimals()
    {
        // Animals needed:
        // 3 Humans
        // 2 Pigs
        // 2 Horses
        // 1 Donkey
        // 1 Raven
        // 1 Goat
        // 2 Dogs, then more dogs later
        // 4 Hens
        // 4 Cows
        // 1 Cat
        // PATTERN: Every first 3 characters speak per day
        Debug.Log("HORSE: " + animals["horse"]);
        currentAnimals.Add(horse);
        currentAnimals.Add(donkey);
        currentAnimals.Add(raven);
        currentAnimals.Add(goat);
        currentAnimals.Add(dog);
        currentAnimals.Add(dog);
        currentAnimals.Add(hen);
        currentAnimals.Add(hen);
        currentAnimals.Add(hen);
        currentAnimals.Add(hen);
        currentAnimals.Add(cow);
        currentAnimals.Add(cow);
        currentAnimals.Add(cow);
        currentAnimals.Add(cow);
        currentAnimals.Add(cat);
        currentAnimals.Add(pig);
        if (currDay > 3)
        {
            currentAnimals.Add(human);
            currentAnimals.Add(human);
            currentAnimals.Add(human);

            currentAnimals.Add(pig);

            currentAnimals.Add(pig);
        }
        // Days 3, 4, 5, 6, 7: All animals
        else if (currDay > 8)
        {
            currentAnimals.Add(pig);

            currentAnimals.Add(horse);
        }
        // Days 8, 9, 10: No Snowball, Day 10 == Boxer
        else if (currDay > 11)
        {
            currentAnimals.Add(horse);

            currentAnimals.Add(dog);
            currentAnimals.Add(dog);
        }
        // Day 11: No Snowball, no Boxer
        else if (currDay == 11)
        {
            currentAnimals.Add(dog);
            currentAnimals.Add(dog);
        }
        // Day 12, 13: End of days, humans come
        else
        {
            currentAnimals.Add(human);
            currentAnimals.Add(human);
            currentAnimals.Add(human);

            currentAnimals.Add(dog);
            currentAnimals.Add(dog);
        }

    }

    // By day, adds the Speak method to certain animals based on which animals are speaking on which days
    void assignDialog()
    {
        string animal1, animal2;
        
        if (currDay == 1)
        {
            animal1 = "human";
            animal2 = "donkey";
        }
        else if (currDay == 2)
        {
            animal1 = "pig";
            animal2 = "cow";
        }
        else if (currDay == 3)
        {
            animal1 = "pig";
            animal2 = "hen";
        }
        else if (currDay == 4)
        {
            animal1 = "dog";
            animal2 = "cat";
        }
        else if (currDay == 5)
        {
            animal1 = "pig";
            animal2 = "donkey";
        }
        else if (currDay == 6)
        {
            animal1 = "pig";
            animal2 = "horse";
        }
        else if (currDay == 7)
        {
            animal1 = "dog";
            animal2 = "dog";
        }
        else if (currDay == 8)
        {
            animal1 = "dog";
            animal2 = "goat";
        }
        else if (currDay == 9)
        {
            animal1 = "raven";
            animal2 = "hen";
        }
        else if (currDay == 10)
        {
            animal1 = "horse";
            animal2 = "cow";
        }
        else if (currDay == 11)
        {
            animal1 = "horse";
            animal2 = "cow";
        }
        else if (currDay == 12)
        {
            animal1 = "donkey";
            animal2 = "cat";
        }
        else
        {
            animal1 = "dog";
            animal2 = "pig";
        }
        int index = System.Array.IndexOf(currentAnimals.ToArray(), animals[animal1]);
        s1 = currentAnimals[index].AddComponent<Speak>();
        index = System.Array.IndexOf(currentAnimals.ToArray(), animals[animal2]);
        s2 = currentAnimals[index].AddComponent<Speak>();
    }
}
