using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //object to collide with

            //Debug.Log("detected");
            Vector3 v1 = a.transform.position;
            Vector3 v2 = transform.position;
            Vector3 v3 = (v1 + v2) / 2;

            

            switch(a.name){
                case "Flask_A":
                    switch(collision.gameObject.name){
                        case "Flask_BT":
                            Instantiate(Resources.Load("Ball"), v3, Quaternion.identity);
                            GameObject.Find("NpcScripts").GetComponent<NpcScript>().ballMade();
                            goodCol = true;
                            break;
                        case "Flask_B":
                            Instantiate(Resources.Load("Ball"), v3, Quaternion.identity);
                            Instantiate(Resources.Load("Gold Trophy"), new Vector3(0.176f, 2.91f, 2.556f), Quaternion.identity);
                            goodCol = true;
                            break;
                    }
                    break;
                case "BakingSoda":
                    switch(collision.gameObject.name){
                        case "Vinegar":
                            Instantiate(Resources.Load("C02"), v3, Quaternion.identity);
                            goodCol = true;
                            break;
                    }
                    break;
            }

        if (goodCol)
        {   
            Destroy(collision.gameObject);
            
            Destroy(a);
            
        }
    }
}
