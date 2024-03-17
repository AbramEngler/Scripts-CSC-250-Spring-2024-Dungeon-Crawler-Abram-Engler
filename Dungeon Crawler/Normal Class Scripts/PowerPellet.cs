using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet 
{
    private string direction;

    private Room roomWithPellets;

    public PowerPellet(string direction, Room roomWithPellets)
    {
        this.direction = direction;
        this.roomWithPellets = roomWithPellets;
    }

    public string getDirection()
    {
        return this.direction;
    }

    public Room getRoomWithPellets()
    {
        return this.roomWithPellets;
    }
}
