using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fightController : MonoBehaviour
{
    public GameObject hero_GO, monster_GO;
    public TextMeshPro hero_hp_TMP;
    public TextMeshPro monster_hp_TMP;
    public TextMeshPro victory_TMP;

    
    private Monster theMonster;
    private Fight theFight;

    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("Zombie");
        this.updateHP();
        this.theFight = new Fight(MySingleton.thePlayer, this.theMonster, this.hero_GO, this.monster_GO, this);
        
        this.theFight.fight();
    }

    public void updateHP()
    {
        this.hero_hp_TMP.text = "HP: " + MySingleton.thePlayer.getHP().ToString() + " AC: " + MySingleton.thePlayer.getAC().ToString();
        this.monster_hp_TMP.text = "Zombie HP: " + this.theMonster.getHP().ToString() + " AC: " + theMonster.getAC().ToString();
    }


    // Update is called once per frame
    void Update()
    {
        if(MySingleton.thePlayer.isDead())
        {
            this.victory_TMP.text = this.theMonster.getName() + " wins!";
            hero_GO.SetActive(false);
        }

        else if(theMonster.isDead())
        {
            this.victory_TMP.text = MySingleton.thePlayer.getName() + " wins!";
            monster_GO.SetActive(false);
        }
    }
}
