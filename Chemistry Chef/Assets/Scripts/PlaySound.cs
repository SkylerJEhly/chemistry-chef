using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    
    public AudioClip sound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    

    void Awake() {
        source = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        source.PlayOneShot(sound, 1F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
