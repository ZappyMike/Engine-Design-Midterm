using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit_Game : MonoBehaviour
{
    public void quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}