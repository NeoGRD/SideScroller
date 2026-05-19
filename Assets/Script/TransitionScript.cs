using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class TransitionScript : MonoBehaviour
{
    /////////////////////////////////////////////////
    
    public Material tr;
    private Material img;
    
    public float transitionSpeed;
    public float transitionTime;
 
    /////////////////////////////////////////////////


    
    void Start()
    {
        img = GetComponent<Graphic>().material;
        Debug.Log(img);
        //img =  new Material(tr);


    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator TransitionEnterTimer()
    {
        float elapsedTime = 0;
        float current = 0;
        float max = 2;
        float min = 0;
        img.SetFloat("_Completion", 0);
        while (elapsedTime < transitionTime)
        {

            current += Time.deltaTime * transitionSpeed;
            elapsedTime += Time.deltaTime;
            img.SetFloat("_Completion",current);
            if (current > max)
            {
                current = max;
            }
            if (current < min)
            { 
                current = min; 
            }
                yield return null;
        }
    }
    public IEnumerator TransitionExitTimer()
    {
        float elapsedTime = 0;
        float current = 2;
        float max = 2;
        float min = 0;
        img.SetFloat("_Completion", 0);
        while (elapsedTime < transitionTime)
        {

            current -= Time.deltaTime * transitionSpeed;
            elapsedTime += Time.deltaTime;
            img.SetFloat("_Completion", current);
            if (current > max)
            {
                current = max;
            }
            if (current < min)
            {
                current = min;
            }
            yield return null;
        }
    }


    public void TransitionEnter()
    {
        img.SetInt("_State", 1);
        StartCoroutine(TransitionEnterTimer());
        return;
    }
    public void TransitionExit()
    {
        img.SetInt("_State", 0);
        StartCoroutine(TransitionExitTimer());
        return;
    }







}
