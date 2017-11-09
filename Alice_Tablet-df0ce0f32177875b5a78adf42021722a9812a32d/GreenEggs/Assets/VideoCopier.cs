using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;


public class VideoCopier : MonoBehaviour
{
    public string nextScene = "";
    WWW vidPosition;
    string Setvid;
    string filePath;
    bool isRunning = false;
    public bool isEditor;
    public string localPath = "";

    [System.Serializable]
    public enum options { Local, SDCard };
    public options dataLocation;
    string shortName;
    public List<string> vidName;
    string vidFolderLocation;
    public bool runOnce = false;
    string vidUID = "";

    void Awake()
    {
        vidFolderLocation = Application.streamingAssetsPath;

        if (dataLocation == options.Local)
            isEditor = true;
        else
            isEditor = false;


        if (PlayerPrefs.HasKey("vidsPresent"))
        {
            bool refresh = false;

            if (!runOnce)
            {
                Debug.Log("Run once not selected. Refresh needed.");
                refresh = true;
            }
            else
            {
                DateTime latestCreationTime = DateTime.MinValue;
                for (int i = 0; i < vidName.Count; i++)
                {
                    string sourceFile = vidFolderLocation + vidName[i] + ".mp4";

                    bool exists = File.Exists(sourceFile);
                    if (!exists)
                    {
                        Debug.Log("Source file " + sourceFile + " doesn't exist. Refresh needed.");
                        refresh = true;
                        break;
                    }
                    else
                    {
                        vidUID += vidName[i];

                        DateTime creationTime = File.GetCreationTime(sourceFile);
                        if (creationTime > latestCreationTime)
                        {
                            latestCreationTime = creationTime;
                        }
                    }
                }

                if (!refresh)
                {
                    vidUID += "_" + latestCreationTime;
                    Debug.Log("New vid UID: " + vidUID + ", old vid UID: " + PlayerPrefs.GetString("vidsPresent"));
                    if (PlayerPrefs.GetString("vidsPresent") != vidUID)
                    {
                        Debug.Log("New vid UID is different from old vid UID. Refresh needed.");
                        refresh = true;
                    }
                }
            }

            if (refresh)
            {
                Debug.Log("Removing vidsPresent key");
                PlayerPrefs.DeleteKey("vidsPresent");
            }
        }
    }

    void Start()
    {
        Debug.Log("vid copying scene launched");
#if UNITY_ANDROID
        Debug.Log("vid copying scene: found Android Run-time");
        if (!PlayerPrefs.HasKey("vidsPresent"))
        {
            if (!isRunning)
            {
                Debug.Log("vidnot present, starting vid copying routine");
                StartCoroutine(copyVid());
            }

        }
        else
        {
            //goToNextScene();
        }
#endif

#if UNITY_IPHONE
		Debug.Log ("Dataset copying scene: found iOS Run-time");
		goToNextScene();
#endif
    }

    IEnumerator copyVid()
    {
        isRunning = true;

        for (int i = 0; i < vidName.Count; i++)
        {
            if (isEditor)
                Setvid = "File:///" + vidFolderLocation + vidName[i] + ".mp4";
            else
                Setvid = vidFolderLocation + vidName[i] + ".mp4";

            vidPosition = new WWW(Setvid);
            yield return vidPosition;

            if (isEditor)
                File.WriteAllBytes(localPath + vidName[i] + ".mp4", vidPosition.bytes);
            else
            {
                Debug.Log("Copying data set from " + Setvid + " to " + Application.persistentDataPath + "/" + vidName[i] + ".mp4");
                File.WriteAllBytes(Application.persistentDataPath + "/" + vidName[i] + ".mp4", vidPosition.bytes);
            }
        }

        yield return new WaitForEndOfFrame();

       

   



        PlayerPrefs.SetString("vidsPresent", vidUID);

        if (!isEditor)
        {
            Debug.Log(" vid succesfully copied to SD Card");
            //goToNextScene();
        }
        else
        {
            Debug.Log(" vid succesfully copied to Local Folder");
           // goToNextScene();
        }
    }

    void goToNextScene()
    {
        if (!string.IsNullOrEmpty(nextScene))
            Application.LoadLevel(nextScene);
        else
            Application.LoadLevel(1);
    }
}
