using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon 
{
    private string name;
    public Room startRoom;
    private Room currentRoom;
    private Player thePlayer;

    public Dungeon(string name)
    {
        this.name = name;
    }

    public void setStartRoom(Room r)
    {
        this.startRoom = r;
    }

    public Room getStartRoom(Room r)
    {
        return this.startRoom;
    }

    public void addPlayer(Player thePlayer)
    {
        this.thePlayer = thePlayer;
        this.startRoom.addPlayer(thePlayer);
    }

}
