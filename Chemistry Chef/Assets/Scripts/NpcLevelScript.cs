  
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
	int maxNum = 12;
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
		texts[0] = "Hello! Welcome to Chemistry Chefs first level. Today your task is a simple one";
		texts[1] = "Combine these reactants and see what happens"; //wait 1 creation of stuff
		texts[2] = "Wow! That was CO2 you just made. This is a reaction you could do in your home";
		texts[3] = "Now lets move on to something more challenging";		
		texts[4] = "Your next task is to create some NaCl. I bought some chips but they didn't give me any salt.";
		texts[5] = "I think I have some things to make some though." ;
		texts[6] = "I will give you 3 reactants and your job is to combine them in the correct order."; //wait 6
		texts[7] = "Good job! Now find a way to boil away the H20"; //wait 7
		texts[8] = "Great! The H20 has evaporated into the gas leaving you with NaCl (Or table salt).";
		texts[9] = "Hey why don't you take a look behind you. I've awarded you a trophy. Feel free to check it out";
		texts[10] = "If you keep working hard you'll be able to keep getting more trophies.";
		texts[11] = "Thanks for playing. More levels to come.";
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
			text.SetText("This is the end of the prototype.");
		}

		if (num == 9){
			Instantiate(Resources.Load("Gold Trophy"), new Vector3(0.176f, 2.91f, 2.556f), Quaternion.identity);
		}
		
	}
	public void setWaitNum(int n)
	{
		waitNum = n;
	}

	public void updateWaitNum(){
		if(waitNum == 1){
			waitNum = 6;
			GameObject.Find("CurrentGoal").GetComponent<TMP_Text>().SetText("Level 2: Create NaCl from the given reactants.");
		}else if(waitNum == 6){
			waitNum = 7;
		}
		else if(waitNum == 7){
			waitNum = maxNum;
		}

	}

	void createLevel(){
		switch(waitNum){
			case 1:
				Instantiate(Resources.Load("Vinegar"), new Vector3(-2.08f, 2.14f, -0.11f), Quaternion.identity);
                Instantiate(Resources.Load("BakingSoda"), new Vector3(-2.08f, 2.35f, -0.8f), Quaternion.identity);
				break;
			case 6:
				Destroy(GameObject.Find("C02(Clone)"));
				Instantiate(Resources.Load("HCl"), new Vector3(-2.08f, 2.14f, -0.3f), Quaternion.identity);
				Instantiate(Resources.Load("NaOH"), new Vector3(-2.08f, 2.35f, -0.9f), Quaternion.identity);
                Instantiate(Resources.Load("NH3"), new Vector3(-1.9f, 2.8f, 0.2f), Quaternion.identity);
				Instantiate(Resources.Load("Burner"), new Vector3(-1.875f, 2.145f, 0.9f), Quaternion.identity);
				Instantiate(Resources.Load("Fries"), new Vector3(-2.56f, 2.25f, -0.3f), Quaternion.identity);
				break;
		}
	}

	IEnumerator WelcomeSound()
	{
		yield return new WaitForSeconds(1);
		source.PlayOneShot(hello, 1F);
	}

}