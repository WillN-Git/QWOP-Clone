using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using UnityEngine;

public class MeterCount : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        text.text = $"{player.position.x:F1} meters";
    }
}
