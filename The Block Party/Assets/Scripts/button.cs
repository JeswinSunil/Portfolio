using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 class button : MonoBehaviour
{
    public void Start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
