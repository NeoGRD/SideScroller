using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class endOfGame : MonoBehaviour
{
    public TransitionScript trS;




    public IEnumerator EndOfGame()
    {
        trS.TransitionEnter();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Congrats");
        yield return null;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(EndOfGame());
    }



}
