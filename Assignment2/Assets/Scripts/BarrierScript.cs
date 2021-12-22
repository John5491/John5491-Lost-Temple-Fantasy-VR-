using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    public Material barrierMaterial;
    public float fadeSpeed = 0.5f;
    // Value used to know when the enemy has been spawned
    private float spawnTime;
    private bool startFadeIn = false;

    // Use this for initialization
    void Start()
    {
        barrierMaterial = GetComponent<MeshRenderer>().material;
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(startFadeIn)
            SetAlpha((Time.time - spawnTime) * fadeSpeed);
    }

    void SetAlpha(float alpha)
    {
        Color color = barrierMaterial.color;
        color.a = Mathf.Clamp(alpha, 0, 1);
        barrierMaterial.color = color;
    }

    private void OnEnable()
    {
        startFadeIn = true;
    }
}
