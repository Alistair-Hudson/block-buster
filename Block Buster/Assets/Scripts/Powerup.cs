using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] int points = 100;
    [SerializeField] Projectile projectile;
    [SerializeField] GameObject effect;

    private void Start()
    {
 
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GetComponent<Rigidbody2D>().IsTouchingLayers(LayerMask.GetMask("Paddle")))
        {
            return;
        }

        if (projectile)
        {
            FindObjectOfType<Paddle>().SetProjectile(projectile);
        }
        
        if (effect)
        {
            GameObject neweffect = Instantiate(effect);
        }
        FindObjectOfType<GameStatus>().AddPoints(points);
        Destroy(gameObject);
       
    }

}
