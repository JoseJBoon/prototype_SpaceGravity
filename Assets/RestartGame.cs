using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public float delay = 10.0f;

    void Start()
    {
        Invoke("Restart", delay);

        GameManager.Instance.TogglePrimaryFirePower();
        GameManager.Instance.transform.GetChild(0).gameObject.SetActive(false);
    }

    void Restart()
    {
        GameManager.Instance.transform.GetChild(0).gameObject.SetActive(true);
        SceneManager.LoadScene("IntroLevel01");
    }
}
