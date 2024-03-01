using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool dead = false;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            text.gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Space) && dead) 
        { 
            dead = false;
            text.gameObject.SetActive(false);

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Layer 9 : Ground
        if (collision.gameObject.layer == 9)
        {
            dead = true;
        }
    }
}
