using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    public GameObject northExitCover;
    public GameObject southExitCover;
    public GameObject eastExitCover;
    public GameObject westExitCover;
    
        // Start is called before the first frame update

    private void turnOffExits()
    {
        this.northExit.gameObject.SetActive(false);
        this.southExit.gameObject.SetActive(false);
        this.eastExit.gameObject.SetActive(false);
        this.westExit.gameObject.SetActive(false);

    }

    void Start()
    {
        turnOffExits();
        Room r = new Room("a room");
        // MySingleton.theRooms[MySingleton.numRooms] = r;
        // MySingleton.numRooms++;
        MySingleton.addRoom(r);

        this.northExitCover.SetActive(false);
        this.southExitCover.SetActive(false);
        this.eastExitCover.SetActive(false);
        this.westExitCover.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        // if(this.northExitCover)
        // {
        //     this.northExit.SetActive(false);
        // }

        // if(this.southExitCover)
        // {
        //     this.southExit.SetActive(false);
        // }

        // if(this.eastExitCover)
        // {
        //     this.eastExit.SetActive(false);
        // }

        // if(this.westExitCover)
        // {
        //     this.westExit.SetActive(false);
        // }
        if(MySingleton.numRooms > 1)
        {
            int ExitSeed = Random.Range(1, 5);
            if (ExitSeed == 1 && MySingleton.amAtMiddleOfRoom == true)
            {
                this.southExit.SetActive(true);
                this.westExit.SetActive(true);
                this.northExitCover.SetActive(true);
                this.eastExitCover.SetActive(true);
            }

            if (ExitSeed == 2 && MySingleton.amAtMiddleOfRoom == true)
            {
                this.northExit.SetActive(true);
                this.southExitCover.SetActive(true);
                this.eastExitCover.SetActive(true);
                this.westExitCover.SetActive(true);
            }

            if (ExitSeed == 3 && MySingleton.amAtMiddleOfRoom == true)
            {
                this.northExit.SetActive(true);
                this.southExit.SetActive(true);
                this.eastExit.SetActive(true);
                this.westExit.SetActive(true);
            }

            if (ExitSeed == 4 && MySingleton.amAtMiddleOfRoom == true)
            {
                this.eastExit.SetActive(true);
                this.southExitCover.SetActive(true);
                this.northExitCover.SetActive(true);
                this.westExitCover.SetActive(true);
            }
            
        }
    }
}
