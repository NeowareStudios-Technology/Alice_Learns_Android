using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSwap : MonoBehaviour {
    // public string first, second, third, fourth, fifth, sixth, seventh, eigth, ninth, tenth;
    public string First, Second, Third, Fourth, Fifth, Sixth, Seventh, Eighth, Ninth, Tenth;
    int currenttext = 1;
    string currentline;
    // Use this for initialization
    void Start () {
		
	}
    private void OnMouseDown()
    {
        currenttext++;
    }
    // Update is called once per frame
    void Update () {
		if (currenttext == 1)
        {
            currentline = First;
            GameObject.Find("Placeholder").GetComponent<Text>().text = currentline;
        }
        if (currenttext == 2)
        {
            currentline = Second;
            GameObject.Find("Placeholder").GetComponent<Text>().text = currentline;
        }
        if (currenttext == 3)
        {
            currentline = Third;

        }
        if (currenttext == 4)
        {
            currentline = Fourth;
        }
        if (currenttext == 5)
        {
            currentline = Fifth;
        }
        if (currenttext == 6)
        {
            currentline = Sixth;
        }
        if (currenttext == 7)
        {
            currentline = Seventh;
        }
        if (currenttext == 8)
        {
            currentline = Eighth;
        }
        if (currenttext == 9)
        {
            currentline = Ninth;
        }
        if (currenttext == 10)
        {
            currentline = Tenth;
        }
    }
}
