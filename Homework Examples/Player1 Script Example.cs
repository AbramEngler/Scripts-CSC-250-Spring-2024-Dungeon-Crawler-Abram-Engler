using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1ScriptExample : MonoBehaviour
{
    private Player thePlayer; 
    public TextMeshPro tm;
    public GameObject destinationGO; //destination GameObject
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        //Vector3.MoveTowards;
        this.thePlayer = new Player("Mike");
        
        tm.text = this.thePlayer.getName() + " -> " + this.thePlayer.getHP();
        // this.tm.transform.position = new Vector3(this.gameObject.transform.position.x, 
        //                                             this.gameObject.transform.position.y + 1, 
        //                                             this.gameObject.transform.position.z);

        //this.gameObject.transform.position = this.destinationGO.transform.position;

        speed = 2.5f;
        
    }

    // Update is called once per frame
    private void Update()
    {
        
        this.thePlayer.display();

        float distance = speed * Time.deltaTime;
        if(Vector3.Distance(this.gameObject.transform.position, this.destinationGO.transform.position) > 3.0f)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, this.destinationGO.transform.position, distance);
        }
        // if(MySingletonExample.player1Turn)
        // {
        //     print("Player 1 " + MySingletonExample.count);
        //     MySingletonExample.count++;
        //     MySingletonExample.player1Turn = false;
        // }
    }

}
