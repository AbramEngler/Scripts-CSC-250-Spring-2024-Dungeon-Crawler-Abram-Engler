using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pellet
{
    protected int bonus; //can only access this with children of this Class
    protected string name;
    public Pellet(int bonus)
    {
        this.bonus = bonus;
        this.name = "pellet";
    }
}
