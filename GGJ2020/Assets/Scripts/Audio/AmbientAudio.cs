using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
  
 
    IEnumerator playEffectsSequentially(List<AudioClip> effects, AudioSource source)
    {
        while (true)
        {
            //Pick a random sound effect
            source.clip = effects[Random.Range(0, effects.Count - 1)];

            source.Play();

            //Rnadomly wait for a new one
            yield return new WaitForSeconds(Random.Range(10, 10));
        }

        
    }

    public List<AudioSource> adSource = new List<AudioSource>();

    public List<AudioClip> metalEffects = new List<AudioClip>();

    public AudioClip softAlarm;
    public AudioClip lowRumble;

    // Start is called before the first frame update
    void Start()
    {
        //Play ambient sounds
        StartCoroutine(playEffectsSequentially(metalEffects, adSource[1]));


        //Low rumble constantly in the background
        adSource[0].clip = lowRumble;
        adSource[0].loop = true;
        adSource[0].Play();


        //Soft alarm in the background, constantly plays
        adSource[2].clip = softAlarm;
        adSource[2].loop = true;
        adSource[2].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
