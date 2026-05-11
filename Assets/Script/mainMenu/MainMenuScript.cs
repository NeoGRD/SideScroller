using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{

    public Scene sceneTr;


    public void OnStartClick()
    {
        SceneManager.LoadScene("SampleScene");
        print("auzhuzrgzva");
    }




    public void OnOptionsClick()
    {
        print("bizou");

    }



    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}