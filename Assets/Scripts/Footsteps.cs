using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : PlayerControls
{
    PlayerControls cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(cc.velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false)
        if(isMoving == true && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }
        //else if(GetComponent<AudioSource>().isPlaying == true && cc.velocity.magnitude < 2f)
        else if(GetComponent<AudioSource>().isPlaying == true && isMoving == false)
        {
            GetComponent<AudioSource>().Pause();
        }
    }
}
