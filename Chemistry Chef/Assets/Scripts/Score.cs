using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int n){
        score = score + n;
        text = GameObject.Find("CurrentScore").GetComponent<Text>();
        text.text = score + "";
    }
}
