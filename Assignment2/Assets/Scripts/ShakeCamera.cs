using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ShakeCamera : MonoBehaviour
{
    public bool shake = false;
    public bool shake1 = false;
    public bool shake2 = false;

    // Update is called once per frame
    void Update()
    {
        if (shake)
        {
            StartCoroutine(go());
            shake = false;
        }
        else if (shake1)
        {
            CameraShaker.Instance.ShakeOnce(3f, 3f, 1f, 1f);
            shake1 = false;
        }
        else if (shake2)
        {
            StartCoroutine(go1());
            shake2 = false;
        }
    }

    private IEnumerator go()
    {
        yield return new WaitForSeconds(3f);
        CameraShaker.Instance.ShakeOnce(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.5f);
        CameraShaker.Instance.ShakeOnce(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.5f);
        CameraShaker.Instance.ShakeOnce(2f, 2f, 1f, 1f);
        yield return new WaitForSeconds(0.5f);
        CameraShaker.Instance.ShakeOnce(2f, 2f, 1f, 1f);
        yield return new WaitForSeconds(0.5f);
        CameraShaker.Instance.ShakeOnce(2f, 2f, 1f, 1f);
    }

    private IEnumerator go1()
    {
        CameraShaker.Instance.ShakeOnce(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(1.5f);
        CameraShaker.Instance.ShakeOnce(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(1.5f);
        CameraShaker.Instance.ShakeOnce(4f, 4f, 1f, 1f);
    }

}
