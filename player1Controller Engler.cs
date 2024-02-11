using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1Controller : MonoBehaviour
{


    // Start is called before the first frame update, MonoBehaviour meaks them be called automatically
    void Start()
    {
        // MySingleton ms = new MySingleton();
        // print(ms.count); //it's ms.count because it is an instance of MySingleton which is non static
        // ms.count++;
    }

    // Update is called once per frame
    void Update()
    {
        MySingleton.Instance.countNext();
    }
}
