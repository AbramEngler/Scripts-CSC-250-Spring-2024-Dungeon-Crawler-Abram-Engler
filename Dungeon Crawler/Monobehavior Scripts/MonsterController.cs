using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private Monster theMonster;
    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("Zombie");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
