using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public AudioSource audioS;
    private AudioClip hover, click, exit;
    // Start is called before the first frame update
    void Start()
    {
        hover = Resources.Load<AudioClip>("Hover");
        click = Resources.Load<AudioClip>("Select");
        exit = Resources.Load<AudioClip>("Exit");
    }


    public void playHover()
    {
        audioS.PlayOneShot(hover);
    }

    public void playClick()
    {
        GameObject.Find("Click").GetComponent<AudioSource>().PlayOneShot(click);
    }

    public void playExit()
    {
        GameObject.Find("Click").GetComponent<AudioSource>().PlayOneShot(exit);
    }
}
