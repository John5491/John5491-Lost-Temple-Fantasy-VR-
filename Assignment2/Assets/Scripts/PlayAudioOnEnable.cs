using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnEnable : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
