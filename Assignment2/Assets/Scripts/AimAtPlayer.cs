using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPlayer : MonoBehaviour
{
    public bool canLook = false;
    public GameObject mainCamera;

    private void Update()
    {
        if(canLook)
            transform.LookAt(mainCamera.transform);
    }
}
