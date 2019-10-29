using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.Translate(Vector3.forward*5*Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.Translate(Vector3.forward * -5 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Rotate(0, -2, 0, Space.Self);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Rotate(0, 2, 0, Space.Self);
        }
    }
}
