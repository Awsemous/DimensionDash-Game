using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void EndGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
