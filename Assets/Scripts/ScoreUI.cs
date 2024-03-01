using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text _scoreText;

    public void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
    }

    public void UpdateScore(ScoreController scoreController)
    {
        _scoreText.text = $"{scoreController.score} meters";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
