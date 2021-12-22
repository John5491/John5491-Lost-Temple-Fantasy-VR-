using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject player;

    void Start()
    {
        StartCoroutine(TheSequence());
    }

    private IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(5);
        cam2.SetActive(true);
        cam1.SetActive(false);
        yield return new WaitForSeconds(6);
        cam3.SetActive(true);
        cam2.SetActive(false);
        yield return new WaitForSeconds(23);
        player.SetActive(true);
        cam3.SetActive(false);
    }
}
