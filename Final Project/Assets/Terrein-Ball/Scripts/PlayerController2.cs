using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 5;
    private Rigidbody rb;
    public int count = 0;

    public AudioSource audio;
    public Text countText;
    public Text winText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // countText.text ;
        winText.text = "";
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {

        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
       // countText.transform.position = namePos;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 mov = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(mov * speed);
    }
    void OnTriggerEnter(Collider other)
    {


        string n = other.GetComponent<Rotator>().x;
        Spawn s = new Spawn();
        if (s.isbalnce(n))
        {
            count = count + 1;
            setCount(s.getparen());
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);

        }
        else
        {

            audio.Play();
        }
    }




    void setCount(int s)
    {
        countText.text = "Count = " + count.ToString();

        if (s == count)
        {
            winText.text = "You captured all";
        }
    }


}