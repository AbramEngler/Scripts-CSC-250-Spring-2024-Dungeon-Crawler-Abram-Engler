using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inhabitant
{
    protected string name;
    protected Room currentRoom;
    protected int hp;
    protected int ac;
    protected int damage;


    public Inhabitant(string name)
    {
        this.name = name;
        this.currentRoom = null;
    }

    public string getName()
    {
        return this.name;
    }
    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }
    
    public void setCurrentRoom(Room r)
    {
        this.currentRoom = r;
    }

    public bool isDead()
    {
        return this.hp <= 0;
    }

    public int getAC()
    {
        return this.ac;
    }

    public int getHP()
    {
        return this.hp;
    }

    public void setDamage(int dmg)
    {
        this.damage = dmg;
    }

    public int getDamage()
    {
        return this.damage;
    }

    public void takeDamage(int damage)
    {
        this.hp = this.hp - damage;
    }
}
