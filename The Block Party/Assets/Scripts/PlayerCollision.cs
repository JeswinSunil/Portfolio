using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public GameManager gamemanager;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "obstacle")
        {

            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();


        }
       
        
    }

    

}
