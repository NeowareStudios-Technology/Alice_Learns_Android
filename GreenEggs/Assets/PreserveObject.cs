using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PreserveObject : MonoBehaviour
{
    void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        print(scene.name);
            DontDestroyOnLoad(transform.root.gameObject);
        
    }
     void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Explore")
        {
            print(scene.name);
            Destroy(this.gameObject);
        }

    }
}
