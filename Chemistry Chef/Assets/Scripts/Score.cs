using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    private Text text;

    public AudioClip correct;
    public AudioClip wrong;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    void Awake() {
        source = GetComponent<AudioSource>();
    }

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
        if (n > 0){
            source.PlayOneShot(correct, 1F);
        }
        else if(n < 0){
            source.PlayOneShot(wrong, 1F);
        }
        
        score = score + n;
        text = GameObject.Find("CurrentScore").GetComponent<Text>();
        text.text = score + "";
    }
}
