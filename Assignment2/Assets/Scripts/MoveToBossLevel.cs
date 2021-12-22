using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToBossLevel : MonoBehaviour
{
    public int level = 2;

    private void OnEnable()
    {
        SceneManager.LoadScene(level);
    }
}
