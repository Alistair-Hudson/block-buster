using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] Powerup[] powerups;
    [SerializeField] float maxPlayAreaWidth = 16f;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 10f;
    [SerializeField] float powerupVelocity = 0;
    [SerializeField] float difficultyFactor = 1000f;

    GameStatus gameStatus;

    IEnumerator Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();

        while (true)
        {

            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            float xPos = transform.position.x + Random.Range(1f, maxPlayAreaWidth - 1f);
            float yPos = transform.position.y;
            Vector2 spawnPos = new Vector2(xPos, yPos);
            Powerup newPowerup = Instantiate(powerups[Random.Range(0, powerups.Length)], spawnPos, Quaternion.identity);
            newPowerup.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -(powerupVelocity + (gameStatus.GetScore() / difficultyFactor)));
            newPowerup.transform.parent = transform;
        }
    }

}
