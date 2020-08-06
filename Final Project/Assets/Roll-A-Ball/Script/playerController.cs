using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerController : MonoBehaviour
{
    
    public float speed;
    public Text countText;
    public Text winText;
    public AudioSource audio;
    private Rigidbody rb;
    private int count=0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
               winText.text = "";
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        string n = other.GetComponent<Rotator>().x;
        Spawn1 s = new Spawn1();
        if (s.check(n))
        {

            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            count = count + 1;

            SetCountText(s.getpalin());
            
        }
        else
        {

            audio.Play();
        }
        
    }

    void SetCountText(int s)
    {
        countText.text = "Count = " + count.ToString();
        
        if (s == count)
        {
            winText.text = "You captured all";
        }
    }
}
