using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System;

public class MySingleton
{
    public static string currentDirection = "?";
    public static Player thePlayer;
    public static Dungeon theDungeon = MySingleton.generateDungeon();

    public static bool isPlayerTurn = false;
    public static bool isMonsterTurn = false;
    public static int currentPellets = 10;

    public static string readJsonString()
    {
        string filePath = "Assets/Data Files/Items_Data.json"; // Path to the file
        string answer = ""; //this function ultimately gives us a string

        // Check if the file exists
        if (File.Exists(filePath))
        {
            try
            {
                Debug.Log("Serialized JSON Parsing");
                // Open the file to read from
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    // Read and display lines from the file until the end of the file is reached
                    while ((line = reader.ReadLine()) != null)
                    {
                        answer = answer + line;
                    }
                    return answer;
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occurred during reading the file
                Debug.Log("An error occurred while reading the file:");
                Debug.Log(ex.Message);
                return null;
            }
        }
        else
        {
            Debug.Log("The file does not exist.");
            return null;
        }
    }

    // public static string readJsonPokeAPI()
    // {
    //     using (UnityWebRequest webRequest = UnityWebRequest.Get("https://pokeapi.co/api/v2/pokemon?limit=1303&offset=0"));
    //     {
            
    //     }
    //     yield return webRequest.SendWebRequest();
    //     string PokeAPI = ; // Path to the file
    //     string answer = ""; //this function ultimately gives us a string

    //     // Check if the file exists
    //     if (File.Exists(filePath))
    //     {
    //         try
    //         {
    //             Debug.Log("Serialized JSON Parsing");
    //             // Open the file to read from
    //             using (StreamReader reader = new StreamReader(filePath))
    //             {
    //                 string line;
    //                 // Read and display lines from the file until the end of the file is reached
    //                 while ((line = reader.ReadLine()) != null)
    //                 {
    //                     answer = answer + line;
    //                 }
    //                 return answer;
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             // Display any errors that occurred during reading the file
    //             Debug.Log("An error occurred while reading the file:");
    //             Debug.Log(ex.Message);
    //             return null;
    //         }
    //     }
    //     else
    //     {
    //         Debug.Log("The file does not exist.");
    //         return null;
    //     }
    // }

    public static string flipDirection(string direction)
    {
        if(direction.Equals("north"))
        {
            return "south";
        }

        else if(direction.Equals("south"))
        {
            return "north";
        }

        else if(direction.Equals("east"))
        {
            return "west";
        }

        else if(direction.Equals("west"))
        {
            return "east";
        }
        else
        {
            Debug.Log(direction + " is not a legal direction in flipDirection inside of MySingleton");
            return "N/A";
        }
    }
    private static Dungeon generateDungeon()
    {
        Room r1 = new Room("R1");
        Room r2 = new Room("R2");
        Room r3 = new Room("R3");
        Room r4 = new Room("R4");
        Room r5 = new Room("R5");
        Room r6 = new Room("R6");

        r1.addExit("north", r2);
        r2.addExit("south", r1);
        r2.addExit("north", r3);
        r3.addExit("south", r2);
        r3.addExit("west", r4);
        r3.addExit("north", r6);
        r3.addExit("east", r5);
        r4.addExit("east", r3);
        r5.addExit("west", r3);
        r6.addExit("south", r3);

        // MySingleton.theDungeon = new Dungeon("the cross");
        // MySingleton.theDungeon.setStartRoom(r1); //theDungeon.setStartRoom also works. 
        // //Through this one Room r1, the Dungeon has access to all the other Rooms

        Dungeon theDungeon = new Dungeon("the cross");
        theDungeon.setStartRoom(r1);

        MySingleton.thePlayer = new Player("Mike");
        theDungeon.addPlayer(MySingleton.thePlayer);
        
        return theDungeon;
    }
}
