using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class ShopController : MonoBehaviour
{
    public TextMeshPro playerTMP, itemTMP;
    // Start is called before the first frame update
    void Start()
    {
        this.updatePlayerTMP();
        this.itemTMP.text = "" + ItemsSingleton.item1Cost;
        //this.readItemsData();

        //read json file with serialization
        string jsonString = MySingleton.readJsonString();

        // Parse the JSON string
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString); //convert this JSON into a RootObject. turns text in JSON into a collection of Items

        // Output the data to the console
        foreach (var item in root.items) //for each item in the item array, we will store that instance of item in items
        {
            //formatted string, placeholders for the values we want to display
            print($"Name: {item.name}, Stat Impacted: {item.stat_impacted}, Modifier: {item.modifier}");
        }
        
    }

    private void updatePlayerTMP()
    {
        this.playerTMP.text = "Pellets: " + MySingleton.currentPellets + "(HP: " + MySingleton.thePlayer.getHP() + ")";
    }

    //    private void readItemsData()
    // {
    //     string filePath = "Assets/Data Files/Items_Data.txt"; // Path to the file
    //     string answer = "";

    //     // Check if the file exists
    //     if (File.Exists(filePath))
    //     {
    //         try
    //         {
    //             // Open the file to read from
    //             using (StreamReader reader = new StreamReader(filePath))
    //             {
    //                 string line;
    //                 string[] itemParts = new string[3];

    //                 int pos = 0;
    //                 // Read and display lines from the file until the end of the file is reached
    //                 while ((line = reader.ReadLine()) != null)
    //                 {
    //                     string[] parts = line.Split(",");
    //                     for (int i = 0; i < parts.Length; i++)
    //                     {
    //                         print(parts[i]);
    //                         itemParts[pos % 3] = parts[i];
    //                         pos++;
    //                     }
    //                     print("Manually parsed with Item Object");
    //                     Item theItem = new Item(itemParts[0], itemParts[1], int.Parse(itemParts[2]));
    //                     theItem.display();
    //                 }
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             // Display any errors that occurred during reading the file
    //             print("An error occurred while reading the file:");
    //             print(ex.Message);
    //         }
    //     }
    //     else
    //     {
    //         print("The file does not exist.");
    //     }
    // }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1)) 
        {
            //charge the player for the item
            if(MySingleton.currentPellets >= ItemsSingleton.item1Cost)
            {
                MySingleton.currentPellets -= ItemsSingleton.item1Cost;
                MySingleton.thePlayer.addHP(5);
                this.updatePlayerTMP();
            }
        }
    }
}
