﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToSheets : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

  public void NextScene()
  {

    SceneManager.LoadScene("Smart Worksheets");
  }
}
