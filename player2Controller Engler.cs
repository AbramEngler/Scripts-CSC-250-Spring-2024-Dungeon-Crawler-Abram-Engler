using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Controller : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        // MySingleton ms = new MySingleton(); //this is a different instance of MySingleton even though they are named "ms"
        // print(ms.count); //it's ms.count because it is an instance of MySingleton which is non static
    }

    // Update is called once per frame
    void Update()
    {
        MySingleton.Instance.countNext();
        
    }
}
