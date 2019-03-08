using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevelBehaviour : MonoBehaviour
{
    [SerializeField]
    string nextLevel = "Level01";

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(!other.CompareTag("Player"))
            return;

        SceneManager.LoadScene(nextLevel);
    }
}
