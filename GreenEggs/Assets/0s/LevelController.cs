
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class LevelController : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("book");
    }
}

