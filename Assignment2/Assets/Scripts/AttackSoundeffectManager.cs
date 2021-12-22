using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSoundeffectManager : MonoBehaviour
{
    public AudioSource warn, ice, laser, rock1, rock2;

    public bool laserS, rock1S, rock2S, warnS, iceS;
    

    // Update is called once per frame
    void Update()
    {
        if(iceS)
        {
            ice.Play();
            iceS = false;
        }
        if (laserS)
        {
            laser.Play();
            laserS = false;
        }
        if (rock1S)
        {
            rock1.Play();
            rock1S = false;
        }
        if (rock2S)
        {
            rock2.Play();
            rock2S = false;
        }
        if (warnS)
        {
            warn.Play();
            warnS = false;
        }
    }
}
