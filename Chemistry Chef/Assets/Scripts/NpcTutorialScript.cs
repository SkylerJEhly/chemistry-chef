  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class NpcTutorialScript : MonoBehaviour
{

    public TMP_Text text;
	public string[] texts;
	public int num = 0;
	int maxNum = 9;
	bool ballmade = false;
	int ballNum = 8;
   
    // Start is called before the first frame update
    void Start()
    {
		
		texts = new string[maxNum];
		texts[0] = "Hello! Welcome to Chemistry Chef take a moment to look around and get used to your surroundings.";//timer
		texts[1] = "To press a button point your controller at the button until you see a green laser, then press A.";
		texts[2] = "If you look on your left (my right) you will see a menu you can interact with. ";
		texts[3] = "If at any time you would like to leave this tutorial press 'Skip Tutorial'.";
		texts[4] = "If your play area is small you may need to teleport";
		texts[5] = "You do this by pointing your right controller at the ground, and pressing the back trigger button";
		texts[6] = "You have two grab buttons on the insides of your controllers.";
		texts[7] = "In order to grab, stick your controller into an object, then press and hold the corresponding grab button.";
		texts[ballNum] = "Make the ball by picking up and colliding the flasks";
		//texts[ballNum+1] = "Goodbye";
		//names may be wrong
        text = GameObject.Find("NpcSpeak").GetComponent<TMP_Text>();
		text.SetText(texts[0]);
		StartCoroutine(nextTextWait());
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

	IEnumerator nextTextWait()
	{
		yield return new WaitForSeconds(5);
		if(num == 0){
        	nextText();
		}
	}
	
	public void nextText()
	{
		num++;
		if(num > ballNum && !ballmade){
			num--;
		}else if(num < maxNum){
			text.SetText(texts[num]);
		}else{
			text.SetText("See you soon!");
			StartCoroutine(GoToLevel000());
		}
		
	}
	public void ballMade()
	{
		ballmade = true;
	}

	IEnumerator GoToLevel000()
	{
        Debug.Log("ahhhh");
		yield return new WaitForSeconds(3);
        Debug.Log("ahhhh the second");
		SceneManager.LoadScene("Level000");
		
	}

}