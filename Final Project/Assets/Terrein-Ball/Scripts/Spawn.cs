using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;

    private GameObject g;

    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLessWait;
    public int startWait;
    public bool stop;
    public static int paren = 0;
    static int counter = 1;
    string str = "(H3)";
    private Vector3[] positionArray = new Vector3[10];
    int randEnemy;

    void Start()
    {

        add();
        //   g = GameObject.FindGameObjectsWithTag ("pick");
        //  StartCoroutine(waitSpawner());


    }
    private void Update()
    {

        //spawnWait = Random.Range(spawnLessWait, spawnMostWait);

    }


    public void add()
    {
        for (int i = 0; i < 23; i++)
        {
            GameObject gameobject;
            Text textobj;

            randEnemy = Random.Range(0, 4);
            float x = Random.Range(-80, 80);
            float z = Random.Range(-80, 80);


            int check = 0;

            if (check == 0)
            {
                Vector3 spawnPosition = new Vector3(x, 1, z);
                string nn = "";
                // Vector3 spawnPosition = positionArray[k];

                /*     int r = Random.Range(0, 2);
                     int size = Random.Range(9, 15);

                     if (r == 0)
                     {



                         nn = RandomString(size);
                     }
                     else
                     {
                         palin = palin + 1;

                         nn = randpalindrom(size);
                         // nn = "" + RandomString(size);
                     }*/

                if (counter % 3 == 0)
                {
                    nn = genrateparen();
                    paren = paren + 1;
                }
                else
                {
                    nn = random();

                }
                counter = counter + 1;


                gameobject = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gameobject.GetComponent<Rotator>().x = nn;
                gameobject.GetComponentInChildren<TextMesh>().text = nn;
            }
        }
    }





    string genrateparen()
    {
        int chker = 0;


        string st = "";

        int len = Random.Range(9, 15);

        for (int i = 0; i < len; i++)
        {
            char c = str[Random.Range(0, str.Length)];
            if (c == ')')
            {
                if (chker > 0)
                {
                    st = st + c;
                    chker = chker - 1;
                }
                else
                {
                    c = str[Random.Range(0, str.Length - 1)];
                    if (c == '(')
                    {
                        st = st + c;
                        chker = chker + 1;
                    }
                    else
                    {
                        st = st + c;
                    }
                }
            }
            else if (c == '(')
            {
                st = st + c;
                chker = chker + 1;
            }
            else
            {
                st = st + c;
            }
        }
        if (chker > 0)
        {
            for (int chk = chker; chk > 0; chk--)
            {
                st = st + ')';
            }
        }
        return "x" + st;

    }

    string random()
    {

        string st = "";

        int len = Random.Range(9, 15);

        for (int m = 0; m < len; m++)
        {
            st = st + str[Random.Range(0, str.Length)];
        }


        return "x" + st;
    }

    public int getparen()
    {
        return paren;
    }
    public bool isbalnce(string s)
    {

        int chker = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c == '(')
            {

                chker = chker + 1;
            }
            if (c == ')')
            {
                if (chker == 0)
                {
                    return false;
                }
                chker = chker - 1;
            }
        }
        if (chker == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}