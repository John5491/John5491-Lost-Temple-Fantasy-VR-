using UnityEngine;

public class FillScreen : MonoBehaviour
{
    void Update()
    {
        transform.localScale = new Vector3(Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height, Camera.main.orthographicSize * 2.0f, 0.1f);
    }
}