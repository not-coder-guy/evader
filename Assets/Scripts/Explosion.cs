using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Animator bomb_explosion;
    public AudioSource bomb_explosion_sound;
    void OnTriggerEnter2D(Collider2D ground)
    {
        // If the bomb hits something
        if (ground.gameObject.tag == "Ground")
        {
            // Play the explosion animation
            bomb_explosion.SetTrigger("explode");

            // Play the explosion sound
            bomb_explosion_sound.Play();

            // Stop the bomb from moving
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().isKinematic = false;

            // Destroy the bomb after the animation is done
            Destroy(gameObject, 1f);
        } else if (ground.gameObject.tag == "Player")
        {
            // Play the explosion animation
            bomb_explosion.SetTrigger("explode");

            // Play the explosion sound
            bomb_explosion_sound.Play();

            // Stop the bomb from moving
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().isKinematic = false;
            
            // Destroy the bomb after the animation is done
            Destroy(gameObject, 1f);
        }
    }
}
