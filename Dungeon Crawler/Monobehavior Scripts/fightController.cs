using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class fightController : MonoBehaviour
{
    public bool isFightOver = false;
    public GameObject hero_GO, monster_GO;
    public TextMeshPro hero_hp_TMP;
    public TextMeshPro monster_hp_TMP;
    public TextMeshPro victory_TMP;
    public TextMeshPro splashText_TMP;
    public GameObject currentAttacker;
    private Animator theCurrentAnimator;

    private bool shouldAttack = true;
    private Monster theMonster;

    // Start is called before the first frame update
    void Start()
    {
        this.splashText_TMP.color = Color.white;
        this.theMonster = new Monster("Zombie");
        this.updateHP();
        
        int num = Random.Range(0, 2); //coin flip, will produce 0 and 1 (since 2 is not included)
        if(num == 0)
        {
            this.currentAttacker = hero_GO;
        }
        else
        {
            this.currentAttacker = monster_GO;
        }

        StartCoroutine(fight());
    }

    public void updateHP()
    {
        this.hero_hp_TMP.text = "HP: " + MySingleton.thePlayer.getHP().ToString() + " AC: " + MySingleton.thePlayer.getAC().ToString();
        this.monster_hp_TMP.text = "Zombie HP: " + this.theMonster.getHP().ToString() + " AC: " + theMonster.getAC().ToString();
    }

    private void tryAttack(Inhabitant attacker, Inhabitant defender)
    {
        this.splashText_TMP.text = "";
        //have attacker hit the defender
        int attackRoll = Random.Range(0,20) + 1;
        if(attackRoll >= defender.getAC())
        {
            //attacker will hit the defender
            int damageRoll = Random.Range(0, 4) + 2; //damage between 2 and 5
            defender.takeDamage(damageRoll);
            if (this.currentAttacker == this.hero_GO)
            {
                this.splashText_TMP.color = Color.red;
                //this.splashText_TMP.text = MySingleton.thePlayer.getName() + " hits for " + damageRoll + " HP!";  
                this.splashText_TMP.text = this.theMonster.getName() + " hits for " + damageRoll + " HP!"; 

            }
            else if(this.currentAttacker == this.monster_GO)
            {
                this.splashText_TMP.color = Color.red;
                //this.splashText_TMP.text = this.theMonster.getName() + " hits for " + damageRoll + " HP!"; 
                this.splashText_TMP.text = MySingleton.thePlayer.getName() + " hits for " + damageRoll + " HP!";  

            }
        }

        else
        {
            print("Attacker Misses!");
            if (this.currentAttacker == this.hero_GO)
            {
                this.splashText_TMP.color = Color.yellow;
                this.splashText_TMP.text = MySingleton.thePlayer.getName() + " misses!"; 
            }
            else if(this.currentAttacker == this.monster_GO)
            {
                this.splashText_TMP.color = Color.yellow;
                this.splashText_TMP.text = this.theMonster.getName() + " misses!"; 
            }
        }
    }

    IEnumerator fight()
    {
        yield return new WaitForSeconds(2);
        if (this.shouldAttack)
        {
            this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
            this.theCurrentAnimator.SetTrigger("attack");

            if (this.currentAttacker == this.hero_GO)
            {
                this.currentAttacker = this.monster_GO;
                this.tryAttack(MySingleton.thePlayer, this.theMonster);
                this.updateHP();

                //now the defender may have fewer hp...check if their are dead?
                if (this.theMonster.isDead())
                {
                    print("Hero Wins!!!!!");
                    this.shouldAttack = false;
                    this.victory_TMP.text = MySingleton.thePlayer.getName() + " wins!";
                    monster_GO.SetActive(false);
                    StopCoroutine(fight());
                    this.isFightOver = true;

                    //yield return new WaitForSeconds(5);
                    MySingleton.currentPellets++;
                    MySingleton.thePlayer.pelletCount++;
                    //EditorSceneManager.LoadScene("DungeonRoom");
                }
                else
                {
                    StartCoroutine(fight());
                }
                
            }
            else
            {
                this.currentAttacker = this.hero_GO;
                this.tryAttack(this.theMonster, MySingleton.thePlayer);
                this.updateHP();
                //now the defender may have fewer hp...check if their are dead?
                if (MySingleton.thePlayer.isDead())
                {
                    print("Monster Wins!!!!!");
                    this.shouldAttack = false;
                    this.victory_TMP.text = this.theMonster.getName() + " wins!";
                    hero_GO.SetActive(false);
                    StopCoroutine(fight());
                    this.isFightOver = true;

                    //yield return new WaitForSeconds(5);

                    MySingleton.thePlayer.setCurrentRoom(MySingleton.theDungeon.startRoom);
                    //EditorSceneManager.LoadScene("DungeonRoom");

                }
                else
                {
                    StartCoroutine(fight());
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFightOver && Input.GetKeyUp(KeyCode.Space))
        {
            MySingleton.thePlayer.resetStats(); //give player HP back after fight
            EditorSceneManager.LoadScene("DungeonRoom");
        }
        
    }
}
