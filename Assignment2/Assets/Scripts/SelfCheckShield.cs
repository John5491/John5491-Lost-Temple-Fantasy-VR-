using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfCheckShield : MonoBehaviour
{
    public GameObject _object;

    // Update is called once per frame
    void Update()
    {
        if(_object.GetComponent<DefenseShield>().shieldInternal < 1f)
        {
            gameObject.SetActive(false);
        }
    }
}
