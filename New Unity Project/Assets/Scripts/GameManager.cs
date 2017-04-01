using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text;
using System.IO;

public class GameManager : MonoBehaviour {

    public string fileName;
    public const int days = 13;

    private List<string> entries = new List<string>();
    private List<List<string>> dialogues = new List<List<string>>();

    // Use this for initialization
    void Start()
    {
        // Add a new dialog for each day - 13 days in total, days can be changed later
        for(int i = 0; i < days; i++)
        {
            dialogues.Add(new List<string>());
        }

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
    }

    bool Load()
    {
        // Handle any problems that might arise when reading the text
        try
        {
            string line;
            // Create a new StreamReader, tell it which file to read and what encoding the file
            // was saved as
            StreamReader theReader = new StreamReader(fileName, Encoding.Default);
            // Immediately clean up the reader after this block of code is done.
            // You generally use the "using" statement for potentially memory-intensive objects
            // instead of relying on garbage collection.
            using (theReader)
            {
                int iter = 0;
                // While there's lines left in the text file, do this:
                do
                {
                    line = theReader.ReadLine();

                    if (line != null)
                    {
                        // Do whatever you need to do with the text line, it's a string now
                        // In this example, I split it into arguments based on comma
                        // deliniators, then send that array to DoStuff()
                        //entries = line.Split(',');
                        //if (entries.Length > 0)
                        {
                            entries.Add(line);
                            iter++;
                        }
                    }
                }
                while (line != null);
                // Done reading, close the reader and return true to broadcast success    
                theReader.Close();
                return true;
            }
        }
        // If anything broke in the try block, we throw an exception with information
        // on what didn't work
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return false;
        }
    }
}
