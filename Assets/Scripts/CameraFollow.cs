using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform followed;
    [SerializeField] private float speed = 10;

    [SerializeField] private Vector3 offset = new(0, 0, -10);

    [SerializeField] private float2 HeightRange = new(0, 0); 
    // Update is called once per frame
    void Update()
    {
        var targetPosition = followed.position + offset;
        targetPosition.y = Mathf.Clamp(targetPosition.y, HeightRange.x, HeightRange.y);
        targetPosition = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        targetPosition = Vector3.Lerp(targetPosition, new(targetPosition.x, followed.position.y + offset.y,targetPosition.z), speed * Time.deltaTime);
        transform.position = targetPosition;
    }
}
