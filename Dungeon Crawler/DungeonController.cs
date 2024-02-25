using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject[] closedDoors;
    
        // Start is called before the first frame update
    private string mapIndexToStringForExit(int index)
    {
        if(index == 0)
        {
            return "north";
        }

        else if(index == 1)
        {
            return "south";
        }

        else if(index == 2)
        {
            return "east";
        }

        else if(index == 3)
        {
            return "west";
        }

        else
        {
            return "?";
        }
    }

    void Start()
    {
        MySingleton.theCurrentRoom = new Room("a room");
        if(MySingleton.numRooms < 1)
        {
            MySingleton.addRoom(MySingleton.theCurrentRoom); //not using this yet
        }
        int openDoorIndex = Random.Range(0,4);
        this.closedDoors[openDoorIndex].SetActive(false); //visually make an open door

        //keep the door you enter from open
        if(MySingleton.currentDirection.Equals("north"))
        {
            this.closedDoors[1].SetActive(false);
        }

        if(MySingleton.currentDirection.Equals("south"))
        {
            this.closedDoors[0].SetActive(false);
        }

        if(MySingleton.currentDirection.Equals("east"))
        {
            this.closedDoors[3].SetActive(false);
        }

        if(MySingleton.currentDirection.Equals("west"))
        {
            this.closedDoors[2].SetActive(false);
        }


        MySingleton.theCurrentRoom.setOpenDoor(this.mapIndexToStringForExit(openDoorIndex));
        if(MySingleton.numRooms < 1)
        {
            for(int i = 0; i < 4; i++)
            {
            //if I am not looking at the already open door
                if(openDoorIndex != i)
                {
                    //should this door be open or not?
                    int coinFlip = Random.Range(0,2);
                    if(coinFlip == 1)
                    {
                        //open the door in that direction
                        this.closedDoors[i].SetActive(false); //visually make an open door
                        MySingleton.theCurrentRoom.setOpenDoor(this.mapIndexToStringForExit(i));

                    }
                }
            }
        }

        else
        {
            this.closedDoors[i] = MySingleton.theRooms[numRooms].closedDoors;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
