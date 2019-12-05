  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class NpcLevelScript : MonoBehaviour
{

    public TMP_Text text;
	private string[] texts;
	private int num = 0;
	int maxNum = 7;
	int waitNum = 1; //increased when level completed

	public AudioClip hello;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
   
	void Awake() {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
		texts = new string[maxNum];
		texts[0] = "Hello! To Chemistry Chefs first level. Today your task is a simple one";
		texts[1] = "Combine these reactants and see what happens"; //wait 1 creation of stuff
		texts[2] = "Wow! That was CO2 you just made this is a reaction you could do in your home";
		texts[3] = "Now lets move on to something more challenging";		
		texts[4] = "Explanation of next level"; //wait 4
		texts[5] = "Explanation of results";
		texts[6] = "More levels to come";
		//names may be wrong
        text = GameObject.Find("NpcSpeak").GetComponent<TMP_Text>();
		text.SetText(texts[0]);
		StartCoroutine(WelcomeSound());
    }


    // Update is called once per frame
    void Update()
    {
		//OVRInput.Update();
	//	OVRInput.FixedUpdate();
		/*if(OVRInput.GetDown(OVRInput.RawButton.A) || Input.GetKey(KeyCode.UpArrow))
		{
			nextText();
		}*/
    }
	
	public void nextText()
	{
		num++;
		if(num > waitNum){
			num--;
		}else if(num < maxNum){
			text.SetText(texts[num]);
			if(num == waitNum){
				//create level
				createLevel();
			}
		}else{
			text.SetText("Error no more text ahhhhh");
		}
		
	}
	public void setWaitNum(int n)
	{
		waitNum = n;
	}

	public void updateWaitNum(){
		if(waitNum == 1){
			waitNum = 4;
		}else if(waitNum == 4){
			waitNum = maxNum;
		}

	}

	void createLevel(){
		switch(waitNum){
			case 1:
				Instantiate(Resources.Load("Vinegar"), new Vector3(-2.08f, 2.14f, -0.11f), Quaternion.identity);
                Instantiate(Resources.Load("BakingSoda"), new Vector3(-2.08f, 2.35f, -0.8f), Quaternion.identity);
				break;
			case 4:
				Instantiate(Resources.Load("HCl"), new Vector3(-2.08f, 2.14f, -0.11f), Quaternion.identity);
				Instantiate(Resources.Load("NaOH"), new Vector3(-2.08f, 2.35f, -0.8f), Quaternion.identity);
                Instantiate(Resources.Load("NH3"), new Vector3(-2.364f, 2.8f, 0.59f), Quaternion.identity);
				Instantiate(Resources.Load("Burner"), new Vector3(-1.875f, 2.145f, 0.9f), Quaternion.identity);
				break;
		}
	}

	IEnumerator WelcomeSound()
	{
		yield return new WaitForSeconds(1);
		source.PlayOneShot(hello, 1F);
	}

}