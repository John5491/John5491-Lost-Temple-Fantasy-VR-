using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneAfterAnother : MonoBehaviour
{
    public AudioSource audioStart;
    public AudioSource audioLoop;
    public float delayOffset = 0.5f;
    void Start()
    {
        audioLoop.loop = true;
        StartCoroutine(playEngineSound());
    }

    IEnumerator playEngineSound()
    {
        audioStart.Play();
        yield return new WaitForSeconds(audioStart.clip.length - delayOffset);
        audioLoop.Play();
    }
}
