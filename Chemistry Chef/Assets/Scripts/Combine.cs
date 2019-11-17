using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    //the transform is the object that is made
    //drag the prefab into the script
    public Transform c;
    public Transform d;
    public GameObject a;
    
    // Start is called before the first frame update
    void Start()
    {
        //place in object a
        //both objects must have ridged bodies
        a = GameObject.Find("Flask_05");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("detected");

        //object to collide with
        if (collision.gameObject.name == "Flask_04")
        {
            //Debug.Log("detected");
            Vector3 v1 = a.transform.position;
            Vector3 v2 = transform.position;
            Vector3 v3 = (v1 + v2) / 2;
            Destroy(collision.gameObject);
            
            Destroy(a);

            Instantiate(c, v3, Quaternion.identity);
            Instantiate(d, new Vector3(0.122f, 3.054f, 2.587f), Quaternion.identity);
        }
    }
}
