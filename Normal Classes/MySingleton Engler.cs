using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton
{
    private static MySingleton instance;
    public int count = 0; 

    public static MySingleton Instance 
    {
        get
        {
            if (instance == null)
            {
                instance = new MySingleton(); 
            } 
            return instance;
        }
    }

    public void countNext()
    {
        Debug.Log($"Player{(count % 2 + 1)}: {count}"); 
        count++;
    }
}
