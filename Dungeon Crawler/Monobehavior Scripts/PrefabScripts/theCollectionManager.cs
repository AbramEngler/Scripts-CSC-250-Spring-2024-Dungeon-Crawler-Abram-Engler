using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theCollectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //read json file with serialization
        string jsonString = MySingleton.readJsonString();

        // Parse the JSON string
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString); //convert this JSON into a RootObject. turns text in JSON into a collection of Items

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
