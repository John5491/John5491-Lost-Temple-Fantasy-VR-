using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class DissolveObject : MonoBehaviour
{
    public GameObject heart;

    [SerializeField] private float noiseStrength = 0.50f;
    [SerializeField] private float objectHeight = 1.0f;
    private bool startFadeIn = false;
    public bool startFadeOut = false;
    private float height = 0.0f;

    private Material material;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {

        if (startFadeIn)
            FadeIn();
        else if(startFadeOut)
            FadeOut();
        if (height > 12f && startFadeIn)
            startFadeIn = false;
        if (height <= 0f && startFadeOut)
        {
            startFadeOut = false;
            gameObject.SetActive(false);
        }
    }

    private void SetHeight(float height)
    {
        material.SetFloat("_CutoffHeight", height);
        material.SetFloat("_NoiseStrength", noiseStrength);
    }
    
    private void OnEnable()
    {
        startFadeIn = true;
    }

    private void FadeIn()
    {
        height += 0.05f;
        SetHeight(height);
    }

    private void FadeOut()
    {
        height -= 0.05f;
        SetHeight(height);
    }
}
