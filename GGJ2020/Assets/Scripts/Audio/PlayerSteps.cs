using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteps : MonoBehaviour
{
    //Two seperate sound files to create dynamic sounding footsteps
    public List<AudioClip> footstep = new List<AudioClip>();

    AudioSource source;

    bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        source = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playStep()
    { 
        source.clip = footstep[Random.Range(0, footstep.Count - 1)];
        source.Play();
        if (isRunning)
        {
            Invoke("playStep", 0.45f);
        }
        else
        {

            Invoke("playStep", 0.65f);
        }

    }

    public void setRunning(bool set)
    {
        isRunning = set;
    }

    public void stopSteps()
    {
        CancelInvoke();
    }

}
