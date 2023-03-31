using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScripts : MonoBehaviour
{

    public int score=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       // if (other.tag == "player")
        //{
            Debug.Log("triggered");
            Destroy(gameObject);
            score = score + 10;
            Debug.Log("SCORE==" + score);
        //}
    }
}
