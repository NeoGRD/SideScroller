using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{

    public Scene sceneTr;

    public GameObject optionMenu;


    public void OnStartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }




    public void OnOptionsClick()
    {  
        gameObject.SetActive(true);
    }
    public void OnOptionsExitClick()
    {
        gameObject.SetActive(false);
    }



    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}