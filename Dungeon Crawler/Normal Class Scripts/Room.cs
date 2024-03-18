using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    private string name;


    private Exit[] theExits = new Exit[4];
    private int howManyExits = 0;
    private Player currentPlayer;

    private Pellet northPellet = null;
    private Pellet southPellet = null;
    private Pellet eastPellet = null;
    private Pellet westPellet = null;

    
    
    public Room(string name)
    {
        this.name = name;
        this.currentPlayer = null;
    }

    public void addPlayer(Player thePlayer)
    {
        this.currentPlayer = thePlayer;
        this.currentPlayer.setCurrentRoom(this); //this updates the player to their new current room
    }

    public void addPellet(Pellet p, string direction)
    {
        if(direction.Equals("north"))
        {
            this.northPellet = p;
        }

        else if(direction.Equals("south"))
        {
            this.southPellet = p;
        }

        else if(direction.Equals("east"))
        {
            this.eastPellet = p;
        }

        else if(direction.Equals("west"))
        {
            this.westPellet = p;
        }

        else
        {
            Debug.Log("Not valid direction");
        }
    }

    public void removePellet(string direction)
    {
        if(direction.Equals("north"))
        {
            this.northPellet = null;
        }

        else if(direction.Equals("south"))
        {
            this.southPellet = null;
        }

        else if(direction.Equals("east"))
        {
            this.eastPellet = null;
        }

        else if(direction.Equals("west"))
        {
            this.westPellet = null;
        }

        else
        {
            Debug.Log("Not valid direction to remove");
        }
    }

    public bool hasPellet(string direction)
    {
        if(direction.Equals("north"))
        {
            return this.northPellet != null;
        }

        else if(direction.Equals("south"))
        {
            return this.southPellet != null;
        }

        else if(direction.Equals("east"))
        {
            return this.eastPellet = !null;
        }

        else if(direction.Equals("west"))
        {
            return this.westPellet != null;
        }

        else
        {
            Debug.Log("Not valid direction to remove");
        }
    }



    public bool hasExit(string direction)
    {
        //does this Room have a exit in the direction of "direction"?
        for(int i = 0; i < this.howManyExits; i++)
        {
            if(this.theExits[i].getDirection().Equals(direction))
            {
                return true;
            }
        }
        return false;
    }

    public void removePlayer(string direction)
    {
        Exit theExit = this.getExitGivenDirection(direction);
        Room destinationRoom = theExit.getDestinationRoom();
        destinationRoom.addPlayer(this.currentPlayer);
        this.currentPlayer = null; //remove the player that just left from this room
    }

    // public bool collectPellet(string direction, Room pelletRoom)
    // {
    //     // bool pelletIsCollected = true;
    //     // return pelletIsCollected;
    //     if(MySingleton.currentDirection.Equals("north"))
    //     {
    //         northPelletIsCollected = true;
    //         return northPelletIsCollected;
    //     }

    //     if(MySingleton.currentDirection.Equals("south"))
    //     {
    //         southPelletIsCollected = true;
    //         return southPelletIsCollected;
    //     }

    //     if(MySingleton.currentDirection.Equals("east"))
    //     {
    //         eastPelletIsCollected = true;
    //         return eastPelletIsCollected;
    //     }

    //     if(MySingleton.currentDirection.Equals("west"))
    //     {
    //         westPelletIsCollected = true;
    //         return westPelletIsCollected;
    //     }

    //     else
    //     {
    //         return false;
    //     }
    // }

    // public bool checkIfPelletIsCollected(string direction, Room pelletRoom)
    // {
    //     bool isPelletCollected = false;
    //     for(int i = 0; i < this.howManyPowerPellets; i++)
    //     {
    //         if(this.thePowerPellets[i].getDirection().Equals(direction))
    //         {
    //             isPelletColleted = true;
    //             return 
    //         }
    //     }
    // }

    private Exit getExitGivenDirection(string direction)
    {
        for(int i = 0; i < this.howManyExits; i++)
        {
            if(this.theExits[i].getDirection().Equals(direction))
            {
                return this.theExits[i]; //returns the exit in the given direction
            }
        }
        return null; //never found the exit
    }

    // public void takeExit(string direction) //take the exit to the destination Room of this exit
    // {
    //     for(int i = 0; i < this.howManyExits; i++)
    //     {
    //         if(this.theExits[i].getDirection().Equals(direction))
    //         {
    //             //we have the exit that leads to the correct room
    //             Room destination = this.theExits[i].getDestinationRoom();
    //             destination.addPlayer(this.currentPlayer);
    //             this.currentPlayer = null;
    //             return;
    //         }
    //     }
    // }

    public void addExit(string direction, Room destinationRoom)
    {
        if(this.howManyExits < this.theExits.Length)
        {
            Exit e = new Exit(direction, destinationRoom);
            this.theExits[this.howManyExits] = e;
            this.howManyExits++;

            // PowerPellet p = new PowerPellet(direction, this);
            // this.thePowerPellets[this.howManyPowerPellets] = p;
            // this.howManyPowerPellets++;
        }
    }
}
