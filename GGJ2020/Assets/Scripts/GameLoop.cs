using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private GameObject _crossFade;
    private bool finishedFadeOut = false, finishedFadeIn = false;

    // Start is called before the first frame update
    private void Awake()
    {
        PlayFadeOut();
    }

    public IEnumerator FadeIn()
    {
        //Play the fade in animation
        _crossFade.GetComponent<Animator>().enabled = true;

        _crossFade.GetComponent<Animator>().Play("FadeIn", 0, 0);


        //Load stuff probably goes here


        //wait for 2 seconds
        yield return new WaitForSeconds(2);

        _crossFade.GetComponent<Animator>().enabled = false;

        finishedFadeIn = true;

        //start fade out 
        //StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        //Play the fade out animation
        _crossFade.GetComponent<Animator>().enabled = true;
        _crossFade.GetComponent<Animator>().Play("FadeOut", 0,0);

        yield return new WaitForSeconds(2);
        _crossFade.GetComponent<Animator>().enabled = false;
        finishedFadeOut = true;
    }

    //Return finished fading
    public bool GetFinishedFadeOut()
    {
        return finishedFadeOut;
    }

    public bool GetFinishedFadeIn()
    {
        return finishedFadeIn;
    }

    // Play the specific animation
    public void PlayFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public void PlayFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
