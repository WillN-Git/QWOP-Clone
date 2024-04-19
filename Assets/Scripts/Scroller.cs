using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    private float _length, _startpos;

    public GameObject cam;
    public float scrollerEffect;
    private void Start()
    {
        _startpos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.transform.position.x > transform.position.x)
        {
            var pos = cam.transform.position + new Vector3(_length / 2 , 0, 0);
            pos.z = 0;
            transform.position= pos;
        }
    }
}
