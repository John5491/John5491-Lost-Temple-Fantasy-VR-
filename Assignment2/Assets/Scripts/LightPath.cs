using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPath : MonoBehaviour
{
    public string pathName;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "easetype", iTween.EaseType.easeInOutSine, "time", time));
    }
}
