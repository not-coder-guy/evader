using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bomb_prefab;
    private float minX = -7.5f;
    private float maxX = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBomb());
    }

    IEnumerator SpawnBomb()
    {
        // wait before dropping the bomb
        yield return new WaitForSeconds(Random.Range(0f, 1f));

        // Spawns a bomb at a random position
        Vector2 spawn_position = new Vector2(Random.Range(minX, maxX), transform.position.y);
        Instantiate(bomb_prefab, spawn_position, Quaternion.identity);

        // call SpawnBomb() again if the game is not over   
        if (Health.instance.health > 0)
        {
            // Debug.Log(Health.instance.health);
            StartCoroutine(SpawnBomb());
        }
    }
}
