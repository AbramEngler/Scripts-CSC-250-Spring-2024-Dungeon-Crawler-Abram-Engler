using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject northDoor, southDoor, eastDoor, westDoor;
    public GameObject northPellet, southPellet, eastPellet, westPellet;

    // Start is called before the first frame update
   
    void Start()
    {
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if(theCurrentRoom.hasExit("north"))
        {
            this.northDoor.SetActive(false);
            if(theCurrentRoom.northPelletIsCollected == false)
            {
                print("North pellet is not collected"); //debug print statements
                this.northPellet.SetActive(true);
            }
        }

        if(theCurrentRoom.hasExit("south"))
        {
            this.southDoor.SetActive(false);
            if(theCurrentRoom.southPelletIsCollected == false)
            {
                print("South pellet is not collected");
                this.southPellet.SetActive(true);
            }
        }

        if(theCurrentRoom.hasExit("east"))
        {
            this.eastDoor.SetActive(false);
            if(theCurrentRoom.eastPelletIsCollected == false)
            {
                print("east pellet is not collected");
                this.eastPellet.SetActive(true);
            }
        }

        if(theCurrentRoom.hasExit("west"))
        {
            this.westDoor.SetActive(false);
            if(theCurrentRoom.westPelletIsCollected == false)
            {
                print("west pellet is not collected");
                this.westPellet.SetActive(true);
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}