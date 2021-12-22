using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSacrificialAltar : MonoBehaviour
{
    public float position = -0.45f;
    public float moveSpeed = 2f;
    Vector3 tempPos = new Vector3();

    private bool startMoving = false;

    private void OnEnable()
    {
        GameObject.Find("OST").GetComponent<AudioSceneTransition>().changeBack();
        startMoving = true;
    }

    private void Update()
    {
        if (startMoving && transform.position.y < position)
        {
            tempPos = transform.position;
            tempPos.y += moveSpeed * Time.deltaTime;
            transform.position = tempPos; 
        }
    }
}
