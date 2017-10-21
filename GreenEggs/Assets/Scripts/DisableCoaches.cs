using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCoaches : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.GetInt("hasTCDisplayed") == 1)
        {
            Destroy(GameObject.Find("Coach"));
        }
        PlayerPrefs.SetInt("hasTCDisplayed", 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
