using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health = 3;
    public int hearts = 3;

    public Image[] heartsArray;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Animator deathAnim;

    public AudioSource gameOverSound;

    public GameObject gameOnUI;
    public GameObject gameOverUI;

    public static Health instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        // If the player's health is greater than max health, set it to max health
        if (health > hearts)
        {
            health = hearts;
        }

        for (int i = 0; i < heartsArray.Length; i++)
        {   
            // If the player's health is greater than the current heart, display the full heart
            if (i < health)
            {
                try
                {
                    heartsArray[i].sprite = fullHeart;
                }
                catch
                {
                    // Debug.Log("Error: No full heart found");
                }
            }
            else
            {   
                try
                {
                    heartsArray[i].sprite = emptyHeart;
                }
                catch
                {
                    // Debug.Log("Error: No empty heart found");
                }
            }

            // Hide the extra hearts
            if (i < hearts)
            {
                try
                {
                    heartsArray[i].enabled = true;
                }
                catch
                {
                    // Debug.Log("Error: No heart found");
                }
            }
            else
            {
                try
                {
                    heartsArray[i].enabled = false;
                }
                catch
                {
                    // Debug.Log("Error: No heart found");
                }
            }
        }
    }

    // If the player collides with the bomb or explosion, take damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            health--;
        }

        if (health <= 0)
        {
            // Play death animation
            deathAnim.SetBool("is_dead", true);
            
            // God lifting the player up
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = -1;
            GetComponent<Rigidbody2D>().isKinematic = false;

            // Play death sound
            gameOverSound.Play();

            // Disable normal GUI
            gameOnUI.SetActive(false);

            // Enable game over GUI
            gameOverUI.SetActive(true);
        }
    }
}
