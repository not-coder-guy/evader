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
                heartsArray[i].sprite = fullHeart;
            }
            else
            {
                heartsArray[i].sprite = emptyHeart;
            }

            // Hide the extra hearts
            if (i < hearts)
            {
                heartsArray[i].enabled = true;
            }
            else
            {
                heartsArray[i].enabled = false;
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
            Debug.Log(health);
            SceneManager.LoadScene(0);
        }
    }
}
