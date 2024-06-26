using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inhabitant
{
    protected string name;
    protected Room currentRoom;
    protected int hp;
    protected int ac;
    protected int maxHP;
    protected int damage;


    public Inhabitant(string name)
    {
        this.name = name;
        this.currentRoom = null;
        this.hp = Random.Range(10, 16);
        this.maxHP = this.hp;
        this.ac = Random.Range(5, 10);
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

    public void addHP(int numHP)
    {
        if(numHP > 0)
        {
            this.hp += numHP;
            if(this.hp > this.maxHP)
            {
                this.hp = this.maxHP; //prevents overheal
            }
        }

        
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
