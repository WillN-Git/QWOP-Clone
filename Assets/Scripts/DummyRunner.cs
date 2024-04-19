using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyRunner : MonoBehaviour, IInputActionSender
{
    public static DummyRunner instance;

    private void Awake()
    {
        if (instance == null) instance = new DummyRunner();
    }

    public int[] SendAction()
    {
        return new int[] { /* Q= */Random.Range(0, 2), /* W= */Random.Range(0, 2), /* O= */Random.Range(0, 2), /* P= */Random.Range(0, 2) };
    }
}
