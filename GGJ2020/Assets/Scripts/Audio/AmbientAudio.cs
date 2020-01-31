using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
    //Fade in and out sounds/music
    //static IEnumerator Fade(AudioSource source, float duration, float targetVolume)
    //{
    //    //Set the current time and get the sources current volume
    //    float currentTime = 0;
    //    float startVolume = source.volume;


    //    //decrease/increase the volume within the time limit
    //    while (currentTime < duration)
    //    {
    //        currentTime += Time.deltaTime;
    //        //Smoothly go from the current volume to the expected one
    //        source.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
    //        yield return null;
    //    }
    //    yield break;
    //}

    IEnumerator playAudioSequentially()
    {
        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < adClips.Count; i++)
        {
            //2.Assign current AudioClip to audiosource
            adSource.clip = adClips[i];

            //3.Play Audio
            adSource.Play();

            //4.Wait for it to finish playing
            while (adSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }

    public List<AudioClip> adClips = new List<AudioClip>();
    public AudioSource adSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playAudioSequentially());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
