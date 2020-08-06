using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public void exit() {
        Debug.Log("game is quit");
        Application.Quit();
    }
}
