using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject m_GotHitScreen;
    [SerializeField]
    float playerhealth = 100;
    float _attackIntensity = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="enemy")
        {
            gethurt();
        }
    }
    void gethurt()
    {
        var color = m_GotHitScreen.GetComponent<Image>().color;
        if (playerhealth < .1f)
        {
            color.a = 1.0f;
            m_GotHitScreen.GetComponent<Image>().color = color;
        }
        else
        {
            color.a += _attackIntensity / playerhealth;
            Debug.Log("Screen color val : " + color.a);
            m_GotHitScreen.GetComponent<Image>().color = color;
            playerhealth -= _attackIntensity;
        }
    }
}
