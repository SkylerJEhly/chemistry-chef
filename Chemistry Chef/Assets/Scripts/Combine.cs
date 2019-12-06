using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Combine : MonoBehaviour
{
    //the transform is the object that is made
    //drag the prefab into the script
    //public Transform c;
    //public Transform d;
    public GameObject a;//me
    //public GameObject b;

    
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
        //Debug.Log("detected");
        bool goodCol = false;
        bool burnCol = false;
        bool hclWrong = false;
        //object to collide with

            //Debug.Log("detected");
            Vector3 v1 = a.transform.position;
            Vector3 v2 = transform.position;
            Vector3 v3 = (v1 + v2) / 2;

            

            switch(a.name){
                case "HCl(Clone)":
                    switch(collision.gameObject.name){
                        case "NaOH(Clone)":
                            Instantiate(Resources.Load("DissolvedNaCl"), v3, Quaternion.identity);
                            NpcLevelScript npc = GameObject.Find("NpcScripts").GetComponent<NpcLevelScript>();
                            npc.updateWaitNum();
                            npc.nextText();
                            goodCol = true;
                            GameObject.Find("CurrentScore").GetComponent<Score>().updateScore(10);
                            break;
                        case "NH3(Clone)":
                            Instantiate(Resources.Load("NH4Cl"), v3, Quaternion.identity);
                            TMP_Text npcText = GameObject.Find("NpcSpeak").GetComponent<TMP_Text>();
                            npcText.SetText("Oops. It looks like you made Ammonium Chloride. Try combining the HCl and NaOH. I've given you some more HCl.");
                            hclWrong = true;
                            goodCol = true;
                            GameObject.Find("CurrentScore").GetComponent<Score>().updateScore(-10);
                            break;
                    }
                    break;
                case "Burner(Clone)":
                    switch(collision.gameObject.name){
                        case "Globe":
                            Instantiate(Resources.Load("Ball"), v3, Quaternion.identity);
                            burnCol = true;
                            break;
                        case "DissolvedNaCl(Clone)":
                            Instantiate(Resources.Load("H2Ogas"), v3 + new Vector3(0,0,0.5f), Quaternion.identity);
                            Instantiate(Resources.Load("Salt"), v3 - new Vector3(0,0,0.5f), Quaternion.identity);
                            NpcLevelScript npc = GameObject.Find("NpcScripts").GetComponent<NpcLevelScript>();
                            npc.updateWaitNum();
                            npc.nextText();
                            burnCol = true;
                            GameObject.Find("CurrentScore").GetComponent<Score>().updateScore(10);
                            break;
                    }
                    break;
                case "Flask_A":
                    switch(collision.gameObject.name){
                        case "Flask_BT":
                            Instantiate(Resources.Load("Ball"), v3, Quaternion.identity);
                            GameObject.Find("NpcScripts").GetComponent<NpcTutorialScript>().ballMade();
                            goodCol = true;
                            break;
                        case "Flask_B":
                            Instantiate(Resources.Load("Ball"), v3, Quaternion.identity);
                            Instantiate(Resources.Load("Gold Trophy"), new Vector3(0.176f, 2.91f, 2.556f), Quaternion.identity);
                            goodCol = true;
                            break;
                    }
                    break;
                case "BakingSoda(Clone)":
                    switch(collision.gameObject.name){
                        case "Vinegar(Clone)":
                            Instantiate(Resources.Load("C02"), v3, Quaternion.identity);
                            NpcLevelScript npc = GameObject.Find("NpcScripts").GetComponent<NpcLevelScript>();
                            npc.updateWaitNum();
                            npc.nextText();
                            goodCol = true;
                            GameObject.Find("CurrentScore").GetComponent<Score>().updateScore(10);
                            break;
                    }
                    break;
            }

        if (goodCol)
        {
            ForceDrop(collision.gameObject);
            Destroy(collision.gameObject);
            ForceDrop(a);
            Destroy(a);

            if (hclWrong){
                Instantiate(Resources.Load("HCl"), v3 - new Vector3(0,0,0.4f), Quaternion.identity);
            }
            
        }
        if(burnCol){
            ForceDrop(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    void ForceDrop(GameObject dropMe)
    {
        GameObject.Find("RightHandAnchor").GetComponent<OVRGrabber>().ForceRelease(dropMe.GetComponent<OVRGrabbable>());
        GameObject.Find("LeftHandAnchor").GetComponent<OVRGrabber>().ForceRelease(dropMe.GetComponent<OVRGrabbable>());
    }
}
