using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Inhabitant
{

    public Monster(string name) : base(name)
    {
        this.ac = 5;
        this.hp = 10;
        //this.damage = Random.Range(1, 6);
    }
}
