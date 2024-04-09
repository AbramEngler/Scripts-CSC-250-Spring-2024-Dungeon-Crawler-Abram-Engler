using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Inhabitant
{
    private int bonusDamage;

    //public int pelletCount;

    public Player(string name) : base(name)
    {        
        // this.ac = 8;
        // this.hp = 15;
        //this.damage = Random.Range(1, 6);
        //this.pelletCount = 0;
        this.bonusDamage = 0;
    }

    // public int getCurrentPelletCount()
    // {
    //     return this.pelletCount;
    // }

    public void resetStats()
    {
        this.hp = this.maxHP;
    }

    public int getBonusDamage()
    {
        return this.bonusDamage;
    }

    public void setBonusDamage(int bonus)
    {
        this.bonusDamage = bonus;
    }
}
