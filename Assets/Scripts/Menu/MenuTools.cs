using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTools : MonoBehaviour
{

    public void GoToScene(int _sceneId) 
    {
        SceneManager.LoadScene(_sceneId);
    }

    public void GameQuit() 
    {
        Application.Quit();
    }

}
