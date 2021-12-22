using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float delayTime = 20f;

    private void Start()
    {
        StartCoroutine(destroyThis());
    }

    private IEnumerator destroyThis()
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(gameObject);
    }
}
