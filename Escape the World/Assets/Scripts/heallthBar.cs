using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heallthBar : MonoBehaviour
{
    //health bar
    public static float health;
    public float MHealth = 100f;
    Image healthBar;//


    // Start is called before the first frame update
    void Start()
    {

        healthBar = GetComponent<Image>();
        health = MHealth;

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / MHealth;
    }
}
