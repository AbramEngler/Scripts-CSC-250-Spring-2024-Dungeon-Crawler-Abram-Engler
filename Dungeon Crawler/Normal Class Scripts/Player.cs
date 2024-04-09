using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Inhabitant
{


    public int pelletCount;

    public Player(string name) : base(name)
    {        
        // this.ac = 8;
        // this.hp = 15;
        //this.damage = Random.Range(1, 6);
        this.pelletCount = 0;
    }

    public int getCurrentPelletCount()
    {
        return this.pelletCount;
    }

    public void resetStats()
    {
        this.hp = this.maxHP;
    }
}
