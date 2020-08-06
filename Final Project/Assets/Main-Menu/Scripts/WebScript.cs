using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebScript : MonoBehaviour
{
    public string Url;
    public void url() {
        Application.OpenURL(Url);
    }
}
