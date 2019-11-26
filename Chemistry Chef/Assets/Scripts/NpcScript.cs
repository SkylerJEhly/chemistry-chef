  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class NpcScript : MonoBehaviour
{

    public TMP_Text text;
	public string[] texts;
	public int num = 0;
	int maxNum = 5;
	bool ballmade = false;
	int ballNum = 4;
   
    // Start is called before the first frame update
    void Start()
    {
		
		texts = new string[maxNum];
		texts[0] = "Hello! Welcome to Chemistry Chef take a moment to look around and get used to your surroundings. Press A to continue";
		texts[1] = "If you look on your left (my right) you will see a menu you can interact with. ";
		texts[2] = "To press a button point your controller at the menu until you see a green laser.";
		texts[3] = "If at any time you would like to leave this tutorial press 'Skip Tutorial'.";		
		texts[4] = "Make the ball by picking up and colliding the flasks";
		texts[5] = "Goodbye";
		//names may be wrong
        text = GameObject.Find("NpcSpeak").GetComponent<TMP_Text>();
		text.SetText(texts[0]);
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
		if(num > ballNum && !ballmade){
			num--;
		}else if(num < maxNum){
			text.SetText(texts[num]);
		}else{
			text.SetText("Goodbye!");
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