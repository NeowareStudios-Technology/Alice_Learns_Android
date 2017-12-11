using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Max_obbLoader : MonoBehaviour {

	//Only use in Preloader Scene for android split APK
	private string nextScene = "Aliceintro";

	public Texture2D background;
	public GUISkin mySkin;
	private bool obbisok=false;

	void Update() {
		if (Application.dataPath.Contains(".obb")&&!obbisok) {
			obbisok=true;
			SceneManager.LoadScene(nextScene);
			// If you need to unpack anything could do it here
			// StartCoroutine(CheckSetUp());
		}
	}

	void OnGUI()
	{
		GUI.skin = mySkin;
		GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label(background,GUILayout.Width(background.width),GUILayout.Height(background.height));
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		if (!obbisok) { 
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label("There is an installation error with this application, Please re-install!");
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}
