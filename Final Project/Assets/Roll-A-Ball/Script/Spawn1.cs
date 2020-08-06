using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Spawn1 : MonoBehaviour
{
    public GameObject[] enemies;

    private GameObject g;

    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLessWait;
    public int startWait;
    public bool stop;
    public static int palin = 0;
    private Vector3[] positionArray = new Vector3[10];
    int randEnemy;

    void Start()
    {

        add();

    }
    private void Update()
    {

        //spawnWait = Random.Range(spawnLessWait, spawnMostWait);

    }


    public void add()
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject gameobject;

            randEnemy = Random.Range(0, 4);
            float x = Random.Range(-9, 9);
            float z = Random.Range(-9, 9);

            int check = 0;

            if (check == 0)
            {
                Vector3 spawnPosition = new Vector3(x, 1, z);

                int r = Random.Range(0, 2);
                int size = Random.Range(9, 15);
                string nn = "";

                if (r == 0)
                {
                    nn = RandomString(size);
                }
                else
                {
                    palin = palin + 1;

                    nn = randpalindrom(size);
                }
                gameobject = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

                gameobject.GetComponent<Rotator>().x = nn;
                // int s = gameobject.transform.GetChildCount();
                g = gameobject;

                g.GetComponentInChildren<TextMesh>().text = nn;

            }
        }
    }

    private string RandomString(int size)
    {

        string _chars = "xH3";
        char[] buffer = new char[size];



        for (int i = 0; i < size; i++)
        {
            buffer[i] = _chars[Random.Range(0, 3)];
        }
        return new string(buffer);
    }

    public void remove(GameObject obj, string name)
    {

        obj.SetActive(false);
        Destroy(obj);

    }
    public string randpalindrom(int size)
    {
        char rem1, rem2;

        char[] str = new char[size];
        int r = Random.Range(0, 3);
        if (r == 1)
        {
            str[0] = '3';
            str[size - 1] = '3';
            rem1 = 'x';
            rem2 = 'H';
        }
        else if (r == 2)
        {
            str[0] = 'H';
            str[size - 1] = 'H';
            rem1 = '3';
            rem2 = 'x';
        }
        else
        {
            str[0] = 'x';
            str[size - 1] = 'x';
            rem1 = 'H';
            rem2 = '3';
        }

        int end = size - 2;
        int i = 1;
        for (i = 1; i < size; i++)
        {
            int x = Random.Range(0, 2);
            if (x == 0)
            {
                str[i] = rem1;
                str[end] = rem1;
            }
            else
            {
                str[i] = rem2;
                str[end] = rem2;

            }
            end--;
            if (end <= i)
            {
                break;
            }
        }

        return new string(str);
    }
    public bool check(string a)
    {

        string b = "";

        int n = a.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            b = b + a[i];
        }
        if (a.Equals(b))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int getpalin()
    {
        return palin;
    }
}