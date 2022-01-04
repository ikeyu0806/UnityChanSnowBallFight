using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float shotSpeed = 10f;
    int attackDamage = 10;
    int score = 100;

    GameObject Player;
    enum Direction { Up, Down, Right, Left };
    Direction shotDirection;

    GameController gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        Player = GameObject.FindWithTag("Player");
        switch (Player.GetComponent<PlayerController>().playerDirection)
        {
            case PlayerController.Direction.Up:
                shotDirection = Direction.Up;
                break;
            case PlayerController.Direction.Down:
                shotDirection = Direction.Down;
                break;
            case PlayerController.Direction.Right:
                shotDirection = Direction.Right;
                break;
            case PlayerController.Direction.Left:
                shotDirection = Direction.Left;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (shotDirection)
        {
            case Direction.Up:
                transform.position += new Vector3(0, 0, shotSpeed) * Time.deltaTime;
                break;
            case Direction.Down:
                transform.position += new Vector3(0, 0, -shotSpeed) * Time.deltaTime;
                break;
            case Direction.Right:
                transform.position += new Vector3(shotSpeed, 0, 0) * Time.deltaTime;
                break;
            case Direction.Left:
                transform.position += new Vector3(-shotSpeed, 0, 0) * Time.deltaTime;
                break;
        }
    }

    public void DamageEnemy(Collision enemy)
    {
        enemy.gameObject.GetComponent<EnemyController>().TakeHit(attackDamage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            DamageEnemy(collision);
            Destroy(gameObject);
        }


        if (collision.gameObject.tag == "EnemyMisaki" || collision.gameObject.tag == "EnemyYuko")
        {
            gameController.AddScore(score);
        }
    }
}
