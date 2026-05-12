using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TransitionScript : MonoBehaviour
{
    /////////////////////////////////////////////////
    
    public Material tr;
    
    
    public float transitionSpeed;
    public float transitionTime;
 
    /////////////////////////////////////////////////


    
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();   

        rend.material =  new Material(tr);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TransitionEnter();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            TransitionExit();
        }
    }
    public IEnumerator TransitionTimer()
    {
        float elapsedTime = 0;
        tr.SetFloat("Completion", 0);
        while (elapsedTime < transitionTime)
        {
            float max = 2;
            float min = 0.05f;
            float current = 0;

            current += Time.deltaTime * transitionSpeed;
            elapsedTime += Time.deltaTime;
            tr.SetFloat("Completion",current);
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
        tr.SetInt("State", 0);
        StartCoroutine(TransitionTimer());
        return;
    }
    public void TransitionExit()
    {
        tr.SetInt("State", 1);
        StartCoroutine(TransitionTimer());
        return;
    }







}
