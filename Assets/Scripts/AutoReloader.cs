using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoReloader : MonoBehaviour
{
    [SerializeField] private int WaitTime = 60;

    private void Start()
    {
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(WaitTime);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
