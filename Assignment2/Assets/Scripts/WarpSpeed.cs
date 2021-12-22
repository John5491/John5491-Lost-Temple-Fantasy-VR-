using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class WarpSpeed : MonoBehaviour
{
    public VisualEffect warpSpeedVFX;
    public MeshRenderer cylinder;
    public GameObject light;
    public float rate = 0.02f;
    public float delay = 2.5f;
    public int loadScene = 2;
    public float lightDelay = 5f;

    public bool needFadeOut = false;

    private bool warpActive;
    void Start()
    {
        light.SetActive(false);
        warpSpeedVFX.Stop();
        warpSpeedVFX.SetFloat("WarpAmount", 0f);
        cylinder.material.SetFloat("_Active", 0f);
    }

    public void activeWarp()
    {
        warpActive = true;
        StartCoroutine(ActivateParticles());
        StartCoroutine(ActivateShader());
        StartCoroutine(ActivateLight());
    }

    public void deactiveWarp()
    {
        warpActive = false;
        StartCoroutine(ActivateParticles());
        StartCoroutine(ActivateShader());
    }

    IEnumerator ActivateParticles()
    {
        if (warpActive)
        {
            warpSpeedVFX.Play();
            float amount = warpSpeedVFX.GetFloat("WarpAmount");
            while (amount < 1 && warpActive)
            {
                amount += rate;
                warpSpeedVFX.SetFloat("WarpAmount", amount);
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {
            warpSpeedVFX.Play();
            float amount = warpSpeedVFX.GetFloat("WarpAmount");
            while (amount > 0 && !warpActive)
            {
                amount += rate;
                warpSpeedVFX.SetFloat("WarpAmount", amount);
                yield return new WaitForSeconds(0.1f);

                if (amount <= 0 + rate)
                {
                    amount = 0;
                    warpSpeedVFX.SetFloat("WarpAmount", amount);
                    warpSpeedVFX.Stop();
                }
            }
        }
    }

    IEnumerator ActivateShader()
    {
        if (warpActive)
        {
            yield return new WaitForSeconds(delay);
            float amount = cylinder.material.GetFloat("_Active");
            while (amount < 1 && warpActive)
            {
                amount += rate;
                cylinder.material.SetFloat("_Active", amount);
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {
            float amount = cylinder.material.GetFloat("_Active");
            while (amount > 0 && !warpActive)
            {
                amount += rate;
                cylinder.material.SetFloat("_Active", amount);
                yield return new WaitForSeconds(0.1f);

                if (amount <= 0 + rate)
                {
                    amount = 0;
                    cylinder.material.SetFloat("_Active", amount);
                }
            }
        }
    }

    IEnumerator ActivateLight()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ShakeCamera>().shake = true;
        yield return new WaitForSeconds(lightDelay);
        if (needFadeOut) GameObject.Find("OST").GetComponent<Animator>().SetTrigger("FadeOut");
        light.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(loadScene);
    }
}
