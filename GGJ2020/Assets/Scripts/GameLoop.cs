using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private GameObject _crossFade;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {

        //Play the fade in animation
        _crossFade.GetComponent<Animator>().enabled = true;
        _crossFade.GetComponent<Animator>().Play("FadeIn", 0, 0);


        //Load stuff probably goes here

        //wait for 2 seconds
        yield return new WaitForSeconds(2);

        //start fade out 
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        //Play the fade out animation
        _crossFade.GetComponent<Animator>().enabled = true;
        _crossFade.GetComponent<Animator>().Play("FadeOut", 0,0);

        yield return new WaitForSeconds(2);
        _crossFade.GetComponent<Animator>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
