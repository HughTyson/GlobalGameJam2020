using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
  
    IEnumerator playAudioSequentially()
    {
        yield return null;

       
            //2.Assign current AudioClip to audiosource
            adSource[0].clip = adClips[Random.Range(0, adClips.Count)];

            //3.Play Audio
            adSource[0].Play();

            //4.Wait for it to finish playing
            while (adSource[0].isPlaying)
            {
                yield return null;
            }

    }

    IEnumerator playEffectsSequentially()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < effects.Count; i++)
        {
            //Pick a random sound effect
            adSource[1].clip = effects[Random.Range(0, effects.Count)];

            adSource[1].Play();

            //Rnadomly wait for a new one
            yield return new WaitForSeconds(Random.Range(10, 20));

        }
    }

    public List<AudioClip> adClips = new List<AudioClip>();
    public List<AudioClip> effects = new List<AudioClip>();
    public List<AudioSource> adSource = new List<AudioSource>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playAudioSequentially());
        StartCoroutine(playEffectsSequentially());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
