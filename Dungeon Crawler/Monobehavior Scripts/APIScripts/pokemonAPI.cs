using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;  // Required for UnityWebRequest
using UnityEngine.UI;         // Required for UI elements like Text
using TMPro;

public class pokemonAPI : MonoBehaviour
{
    public Material placeHolderMaterial;
    public GameObject itemPrefab;
    private Vector3 startPosition;
    private int itemSpawned = 0;
    private int currentLeftPos = 0;
    private List<GameObject> theItemsGO = new List<GameObject>();
    void Start()
    {
        StartCoroutine(GetRequest("https://pokeapi.co/api/v2/pokemon?limit=1302&offset=0"));
    }

    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
     
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                print("Error: " + webRequest.error);
            }
            else
            {
                // Show results as text
                //print(webRequest.downloadHandler.text);
                // Or retrieve results as binary data
                //byte[] results = webRequest.downloadHandler.data;
                CollectionOfPokemon theCollectionOfPokemon = JsonUtility.FromJson<CollectionOfPokemon>(webRequest.downloadHandler.text);

                for(int i = 0; i < theCollectionOfPokemon.count; i++)
                {
                
                    this.startPosition = new Vector3(-3.8f + (this.itemSpawned * 2.45f), 0f, 0f);
                    GameObject newObject = Instantiate(this.itemPrefab, this.startPosition, Quaternion.identity);
                    TextMeshPro tmp = newObject.transform.GetChild(0).GetComponent<TextMeshPro>();
                    tmp.SetText(theCollectionOfPokemon.results[i].name + "\n \n URL: " + theCollectionOfPokemon.results[i].url);
                    newObject.transform.SetParent(this.gameObject.transform);
                    newObject.transform.localPosition = this.startPosition;
                    newObject.transform.localRotation = Quaternion.identity;
                    if(this.itemSpawned >= 4)
                    {
                        newObject.SetActive(false);
                    }
                    this.itemSpawned++;
                    this.theItemsGO.Add(newObject);
                }
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow) && this.currentLeftPos <= this.theItemsGO.Count - 5)
        {
            //move everything left one item
            GameObject tempLeft = null, tempRight = null;

            //goes through our items and moves them appropriately and makes them visible/invisible as needed
            for(int i = 0; i < this.theItemsGO.Count; i++)
            {
                this.theItemsGO[i].transform.Translate(Vector3.left * 10.0f);
                if(i == this.currentLeftPos)
                {
                    tempLeft = this.theItemsGO[i];
                }

                if(i == this.currentLeftPos + 4)
                {
                    tempRight = this.theItemsGO[i];
                }
            }
            tempLeft.SetActive(false);
            tempRight.SetActive(true);
            this.currentLeftPos++;

        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && this.currentLeftPos >= 1)
        {
            //move everything left one item
            GameObject tempLeft = null, tempRight = null;

            for (int i = 0; i < this.theItemsGO.Count; i++)
            {
                this.theItemsGO[i].transform.Translate(Vector3.right * 10.0f);
                if (i == this.currentLeftPos - 1)
                {
                    tempLeft = this.theItemsGO[i];
                }

                if (i == this.currentLeftPos + 3)
                {
                    tempRight = this.theItemsGO[i];
                }
            }
            tempLeft.SetActive(true);
            tempRight.SetActive(false);
            this.currentLeftPos--;

        }
    }
}