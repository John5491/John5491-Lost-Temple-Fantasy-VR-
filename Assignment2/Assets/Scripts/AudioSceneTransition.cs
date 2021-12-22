using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSceneTransition : MonoBehaviour
{
    public AudioClip oriClip;
    public AudioClip newClip;
    public AudioSource audioS;

    private Animator anim;

    private void Start()
    {
        audioS.clip = oriClip;
        audioS.Play();
        anim = GetComponent<Animator>();
    }

    public void changeClip()
    {
        anim.SetTrigger("FadeOut");
        StartCoroutine(switchClip());
    }

    private IEnumerator switchClip()
    {
        yield return new WaitForSeconds(2f);
        audioS.clip = newClip;
        audioS.Play();
        anim.SetTrigger("FadeIn");
    }

    public void changeBack()
    {
        anim.SetTrigger("FadeOut");
        StartCoroutine(switchBack());
    }

    private IEnumerator switchBack()
    {
        yield return new WaitForSeconds(2f);
        audioS.clip = oriClip;
        audioS.Play();
        anim.SetTrigger("FadeIn");
    }
}
