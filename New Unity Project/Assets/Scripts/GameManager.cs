using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text;
using System.IO;

public class GameManager : MonoBehaviour {

    public string fileName;

    private ArrayList entries = new ArrayList();

    // Use this for initialization
    void Start()
    {
        if (Load())
        {
            for (int i = 0; i < entries.Count; i++)
            {
                Debug.Log(entries[i]);
                Debug.Log(entries[i].ToString().Substring(0, 1));
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
