using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeBehaviour : MonoBehaviour
{
    PlayerMovement playerMovement;

    void Awake()
    {
        // playerMovement = GameObject.FindWithTag("Player");
        playerMovement = FindObjectOfType<PlayerMovement>();
        Time.timeScale = 1f;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            playerMovement.GetComponent<SpriteRenderer>().color = Color.red;
            Time.timeScale = 0f;
            SceneManager.LoadScene(0);
        }
    }
}
