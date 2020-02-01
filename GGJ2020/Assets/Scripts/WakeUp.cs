using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUp : MonoBehaviour
{
    private Camera cam;
    
    private bool completed = false;
    private Quaternion start;
    private Quaternion end;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = Camera.main.GetComponent<Animator>();
        //start = new Quaternion.Euler(15, cam.transform.rotation.y, cam.transform.rotation.z, cam.transform.rotation.w);
        //end = new Quaternion.Euler(cam.transform.rotation.x, cam.transform.rotation.y, cam.transform.rotation.z, cam.transform.rotation.w);

        //cam.transform.rotation = start; 
        StartCoroutine(wake());
    }

    IEnumerator wake()
    {
        GetComponent<CharacterCtrl>().imAwake = false;
        animator.enabled = true;
        animator.Play("camera_wake_up");
        yield return new WaitForSeconds(1.5f);
        animator.enabled = false;
        GetComponent<CharacterCtrl>().imAwake = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {
            //cam.
        }
    }
}
