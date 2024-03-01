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
    }

    void FixedUpdate()
    {
        Debug.Log("HEY");

        float temp = (cam.transform.position.x * (1 - scrollerEffect));
        float dist = (cam.transform.position.x * scrollerEffect);

        transform.position = new Vector3(_startpos + dist, transform.position.y, transform.position.z);

        if (temp > _startpos + _length) _startpos += _length;
        else if (temp < _startpos - _length) _startpos -= _length;
    }
}
