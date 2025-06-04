using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandlers : MonoBehaviour
{

    public void quitButton()
    {
        Application.Quit();
    }
    
    
    
    public void LoadScene()
    {
        SceneManager.LoadScene("FirstScene");
    }
}
