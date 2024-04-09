using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;


public class ShopKeeperController : MonoBehaviour
{
    public GameObject item1;
    public int item1Cost;
    public TextMeshPro item1_TMP;
    public TextMeshPro playerShopPelletCount_TMP;

    // Start is called before the first frame update
    void Start()
    {
        this.playerShopPelletCount_TMP.text = "" + MySingleton.currentPellets;
        this.item1_TMP.text = "3 Pellets";
        this.item1Cost = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(MySingleton.currentPellets >= item1Cost && Input.GetKeyUp(KeyCode.Alpha1))
        {
            MySingleton.currentPellets = MySingleton.currentPellets - item1Cost;
            this.playerShopPelletCount_TMP.text = "" + MySingleton.currentPellets;
            this.item1.SetActive(false);
            this.item1_TMP.text = "";
            MySingleton.thePlayer.setBonusDamage(100);
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            EditorSceneManager.LoadScene("DungeonRoom");
        }
    }
}
