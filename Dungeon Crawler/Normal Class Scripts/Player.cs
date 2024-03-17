using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string name;
    private Room currentRoom;

    public int pelletCount;

    public Player(string name)
    {
        this.name = name;
        this.currentRoom = null;
        this.pelletCount = 0;
    }

    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }
    
    public void setCurrentRoom(Room r)
    {
        this.currentRoom = r;
    }

    public int getCurrentPelletCount()
    {
        return this.pelletCount;
    }
}
