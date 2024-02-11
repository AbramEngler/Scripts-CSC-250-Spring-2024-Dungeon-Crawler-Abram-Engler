using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2ScriptExample1 : MonoBehaviour
{
    private Player thePlayer; 
    public TextMeshPro tm;
    
    // Start is called before the first frame update
    void Start()
    {
        this.thePlayer = new Player("Dave");
        
        tm.text = this.thePlayer.getName() + " -> " + this.thePlayer.getHP();
        
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        this.thePlayer.display();
        // if (MySingletonExample.player1Turn == false)
        // {
        //     print("Player 2 " + MySingletonExample.count);
        //     MySingletonExample.count++;
        //     MySingletonExample.player1Turn = true;
        // }
    }
}
