using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void StartLevel000()
    {
        SceneManager.LoadScene("Level000");
    }
}