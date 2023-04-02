using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;

    public int Currentscore;
    public TMP_Text Scoretext;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        Currentscore = 0;
    }
    public void HandleScore()
    {
        Scoretext.text = "SCORE" + Currentscore;
    }
}