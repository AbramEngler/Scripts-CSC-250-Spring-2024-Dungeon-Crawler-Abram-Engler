using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string SceneName;
    public GameObject Player;
    void OnTriggerEnter(Collider other)
    {
        EditorSceneManager.LoadScene(SceneName);
        //EditorSceneManager.MoveGameObjectToScene(Player, EditorSceneManager.GetSceneByName(SceneName));
    }
}
