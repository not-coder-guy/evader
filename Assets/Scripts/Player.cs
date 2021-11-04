using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{    
    public float speed = 10f;
    private float minX = -7.5f;
    private float maxX = 7.5f;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        // Call Player Movement Function
        MovePlayer();
    }

    // Player Movement Function
    void MovePlayer()
    {
        // Get Horizontal Input
        float x = Input.GetAxis("Horizontal");

        Vector2 move = transform.position;

        // Player Movement Animation
        animator.SetFloat("speed", Mathf.Abs(x));

        // Get Player Scale & Direction of Face
        Vector2 characterScale = transform.localScale;  

        // Set Player Direction & Face Direction
        if (x > 0) {
            // Going to Right Side
            move.x += speed * Time.deltaTime;
            // Debug.Log("Going to Right Side");
            characterScale.x = 5;
        } else if (x < 0) {
            // Going to Left Side
            move.x -= speed * Time.deltaTime;
            // Debug.Log("Going to Left Side");
            characterScale.x = -5;
        }

        // Set Player Face Direction
        transform.localScale = characterScale;

        // Limit Player Movement to Screen
        if (move.x < minX) {
            move.x = minX;
        } else if (move.x > maxX) {
            move.x = maxX;
        }

        // Output Player Movement
        transform.position = move;
    }
}
