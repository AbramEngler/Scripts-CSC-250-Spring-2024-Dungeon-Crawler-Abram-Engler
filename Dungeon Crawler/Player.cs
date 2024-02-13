using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject Exit;
    public GameObject Entrance;
    public GameObject Center;
    public GameObject Spawn;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2.5f;
        float distance = speed * Time.deltaTime;
        this.transform.position = this.Spawn.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("onCollision");
    }

    private void OnTriggerEnter(Collider other)
    {
        //DontDestroyOnLoad(this);
        //DontDestroyOnLoad(this.Center);
        this.transform.position = this.Entrance.transform.position;
        this.Exit = null;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = speed * Time.deltaTime;
        if(this.Exit)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.Exit.transform.position, distance);
        }
        else if (Vector3.Distance(this.transform.position, this.Center.transform.position) > 2.0f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.Center.transform.position, distance);
        }
    }
}
