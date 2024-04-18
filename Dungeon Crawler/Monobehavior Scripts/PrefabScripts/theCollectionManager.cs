using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theCollectionManager : MonoBehaviour
{
    public int itemPage = 0;
    public int itemPerPage = 4;
    public GameObject item1, item2, item3, item4, item5, item6, item7, item8;

    //public GameObject[] itemArray;
   
    

    // Start is called before the first frame update
    void Start()
    {
        //read json file with serialization
         string jsonString = MySingleton.readJsonString();
        
        //         // Parse the JSON string
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString); //convert this JSON into a RootObject. turns text in JSON into a collection of Items

        
        // foreach (var item in root.items) //for each item in the item array, we will store that instance of item in items
        // {
        //     //formatted string, placeholders for the values we want to display
        //     print($"Name: {item.name}, Stat Impacted: {item.stat_impacted}, Modifier: {item.modifier}");
        // }
        
        
    }

    public void displaySelectedItem()
    {
        string jsonString = MySingleton.readJsonString();
        
            // Parse the JSON string
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString);

        if(Input.GetKeyUp(KeyCode.Alpha1) && itemPage == 0)
            {
                root.items[0].display();
            }
        
        else if(Input.GetKeyUp(KeyCode.Alpha2) && itemPage == 0)
            {
                root.items[1].display();
            }

        else if(Input.GetKeyUp(KeyCode.Alpha3) && itemPage == 0)
            {
                root.items[2].display();
            }
        
        else if(Input.GetKeyUp(KeyCode.Alpha4) && itemPage == 0)
            {
                root.items[3].display();
            }
        
        else if(Input.GetKeyUp(KeyCode.Alpha1) && itemPage == 1)
            {
                root.items[4].display();
            }
        
        else if(Input.GetKeyUp(KeyCode.Alpha2) && itemPage == 1)
            {
                root.items[5].display();
            }
        
        else if(Input.GetKeyUp(KeyCode.Alpha3) && itemPage == 1)
            {
                root.items[6].display();
            }
        
        else if(Input.GetKeyUp(KeyCode.Alpha4) && itemPage == 1)
            {
                root.items[7].display();
            }

    }

    // Update is called once per frame
    void Update()
    {
        this.displaySelectedItem();
        if (Input.GetKeyUp(KeyCode.LeftArrow) && itemPage > 0)
        {
            string jsonString = MySingleton.readJsonString();
        
            // Parse the JSON string
            RootObject root = JsonUtility.FromJson<RootObject>(jsonString);
            itemPage--;

            item1.SetActive(true);

            item2.SetActive(true);
            

            item3.SetActive(true);
            

            item4.SetActive(true);
            

            item5.SetActive(false);
            item6.SetActive(false);
            item7.SetActive(false);
            item8.SetActive(false);
        }
       if (Input.GetKeyUp(KeyCode.RightArrow) && itemPage < 1)
        {
            string jsonString = MySingleton.readJsonString();
        
            // Parse the JSON string
            RootObject root = JsonUtility.FromJson<RootObject>(jsonString);
            itemPage++;
            item5.SetActive(true);
            

            item6.SetActive(true);
            

            item7.SetActive(true);
            

            item8.SetActive(true);
            

            item1.SetActive(false);
            item2.SetActive(false);
            item3.SetActive(false);
            item4.SetActive(false);
        }
    }
}
