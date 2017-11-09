using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

[CustomEditor(typeof(VideoCopier))]
public class VideoCopierEditor : Editor
{

    [System.Serializable]
    public enum options { Local, SDCard };
    public options dataLocation;
    int index = 0;
    VideoCopier _target;
    private string entry;
    string shortName;
    bool isCalculated = false;

    void OnEnable()
    {

        _target = (VideoCopier)target;

    }

    override public void OnInspectorGUI()
    {

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        Texture2D cambrianNews = AssetDatabase.LoadMainAssetAtPath("Assets/DataSetLoader/Logo/rflogo.png") as Texture2D;
        GUILayout.Label(cambrianNews, GUILayout.Height(200));

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUI.color = Color.green;

        if (_target.vidName.Count == 0)
        {
            if (GUILayout.Button("Calculate Video", GUILayout.Width(120)))
            {
                copyVideo();
            }
        }

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUI.color = Color.white;

        for (int i = 0; i < _target.vidName.Count; i++)
        {
            EditorGUILayout.LabelField("Video: " + _target.vidName[i], EditorStyles.whiteLabel);
        }

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUI.color = Color.yellow;

        if (_target.vidName.Count != 0)
        {
            if (GUILayout.Button("Reset Video", GUILayout.Width(120)))
            {
                resetVid();
            }
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUI.color = Color.white;

        if (_target.vidName.Count != 0)
        {
            _target.nextScene = EditorGUILayout.TextField("Next Scene: ", _target.nextScene, EditorStyles.textField);

            _target.runOnce = EditorGUILayout.Toggle("Run Only Once: ", _target.runOnce, EditorStyles.radioButton);

            EditorGUILayout.HelpBox("Enter the name of the next scene to load. If empty, the level with ID 1 will be loaded", MessageType.Info);

            GUI.color = Color.white;

            EditorGUILayout.LabelField("Video Location:", EditorStyles.whiteLabel);

            if (_target.dataLocation == VideoCopier.options.Local)
                GUI.color = Color.red;
            else
                GUI.color = Color.green;

            _target.dataLocation = (VideoCopier.options)EditorGUILayout.EnumPopup(_target.dataLocation);

            GUI.color = Color.white;

            if (_target.dataLocation == VideoCopier.options.Local)
            {
                EditorGUILayout.HelpBox("WARNING! Remember to select SDCard before you build the app.", MessageType.Warning)
                        ;
                _target.localPath = EditorGUILayout.TextField("Local Path: ", _target.localPath);

                EditorGUILayout.HelpBox("Enter the full path of a local folder to check if the script is working right.", MessageType.Info);
            }
        }

        if (GUI.changed) EditorUtility.SetDirty(_target);

    }

    void copyVideo()
    {

        DirectoryInfo dirD = new DirectoryInfo(Application.streamingAssetsPath);

        FileInfo[] infoD = dirD.GetFiles("*mp4*");

        foreach (FileInfo d in infoD)
        {
            string fullName = d.Name;
            shortName = fullName.Replace(".mp4", "");

            if (!shortName.Contains("meta"))
            {

                _target.vidName.Add(shortName);

            }

        }

        isCalculated = true;
    }

    void resetVid()
    {
        _target.vidName.Clear();
        isCalculated = false;
    }
}
