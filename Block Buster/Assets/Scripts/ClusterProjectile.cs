using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterProjectile : MonoBehaviour
{
    [SerializeField] Projectile bombPrefab;
    [SerializeField] int numOfBombs = 4;
    [SerializeField] float projectileSpeed = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        float angle = 2 * Mathf.PI / numOfBombs;
        for (int i = 0; i < numOfBombs; ++i)
        {
            float xVelocity = projectileSpeed * Mathf.Sin(i * angle);
            float yVelocity = projectileSpeed * Mathf.Cos(i * angle);
            Projectile projectile = Instantiate(bombPrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);

        }
    }
}
