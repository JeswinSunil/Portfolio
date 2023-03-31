using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Playerctrl : MonoBehaviour
{
    public float speed = 4f;
    private float movem = 0f;
    private Rigidbody2D rigbod;
    //jump
    public float jumpSpeed = 0;
    // making the layer to stop up.
    public Transform groundCheckPoint;//pisition
    public float groundCheckRadius;//radius
    public LayerMask groundLayer;//anything specified by u.
    private bool istouchingGrond;// bool true/fals
    // animator clss refrnc created
    private Animator PlayeAnim;
    public Vector3 Respawnpoi;




    void Start()
    {
        rigbod = GetComponent<Rigidbody2D>();
        PlayeAnim = GetComponent<Animator>();
        Respawnpoi = transform.position;


    }

    void Update()
    {
        istouchingGrond = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        movem = Input.GetAxis("Horizontal");

        if (movem > 0f)
        {
            rigbod.velocity = new Vector2(movem * speed, rigbod.velocity.y);
            //for change face
            transform.localScale = new Vector2(0.2667074f, 0.2667074f);


        }
        else if (movem < 0f)
        {
            rigbod.velocity = new Vector2(movem * speed, rigbod.velocity.y);
            transform.localScale = new Vector2(-0.2667074f, 0.2667074f);

        }
        else
        {
            //it will simply keep movementa in x-axis 0/zero.
            rigbod.velocity = new Vector2(0, rigbod.velocity.y);
        }

        // vertical 
        movem = Input.GetAxis("Vertical");

        if (movem > 0f)
        {
            rigbod.velocity = new Vector2(rigbod.velocity.x, movem * speed);
        }
        else if (movem < 0f)
        {
            rigbod.velocity = new Vector2(rigbod.velocity.x, movem * speed);
        }

        if (Input.GetButtonDown("Jump") && istouchingGrond)
        {
            //jumpsp = for space key
            rigbod.velocity = new Vector2(rigbod.velocity.x, jumpSpeed);
        }
        PlayeAnim.SetFloat("Speed", Mathf.Abs(rigbod.velocity.x));
        PlayeAnim.SetBool("GroundTouch", istouchingGrond);




    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "falldetector")
        {
            Debug.Log("njn chathu");
            // we will add but we need to understand how to add check point and then from there we can respawn

        }
        if (other.tag == "spikes")
        {

            Debug.Log("triggered");
            transform.position = Respawnpoi;

        }
        if (other.tag == "checkpoint")
        {
            Respawnpoi = other.transform.position;
        }
        if (other.tag == "teleporter")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}