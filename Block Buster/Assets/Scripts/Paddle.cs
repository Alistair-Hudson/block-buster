using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //configuration paramters
    [SerializeField] Projectile projectile;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float projectileSpeed = 5f;


    // Cahed Data
    GameStatus gameStatus;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), 0, screenWidthInUnits);
        transform.position = paddlePos;
        if (Input.GetButtonDown("Fire1"))
        {
            Projectile newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        }
    }

    private float GetXPos()
    {
        if (gameStatus.IsAutoPlay())
        {
            return ball.transform.position.x;
        }
        return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
}
