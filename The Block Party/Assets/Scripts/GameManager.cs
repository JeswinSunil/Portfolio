using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gamehasended = false;
    public float restartDelay = 2f;
   // public GameObject levelcompleteUI;

    //public void CompleteLevel()
    //{
    //    levelcompleteUI.SetActive(true);
    //}
    public void EndGame()
    {
        if(gamehasended == false)
        {
            gamehasended = true;
            Debug.Log("game over");
            Invoke("Restart",restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
    //public void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.tag == "WIN")
    //    {
    //        SceneManager.LoadScene("Level02");
    //    }
    //}
}
