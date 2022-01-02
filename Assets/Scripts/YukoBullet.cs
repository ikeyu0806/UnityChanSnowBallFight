using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukoBullet : MonoBehaviour
{
    float shotSpeed = 10f;
    int attackDamage = 10;

    GameObject Player;
    GameObject YukoModel;
    enum Direction { Up, Down, Right, Left };
    Direction shotDirection;

    // Start is called before the first frame update
    void Start()
    {
        YukoModel = GameObject.Find("EnemyYuko");
        switch (YukoModel.GetComponent<BossEnemy>().bossDirection)
        {
            case BossEnemy.Direction.Up:
                shotDirection = Direction.Up;
                break;
            case BossEnemy.Direction.Down:
                shotDirection = Direction.Down;
                break;
            case BossEnemy.Direction.Right:
                shotDirection = Direction.Right;
                break;
            case BossEnemy.Direction.Left:
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
        enemy.gameObject.GetComponent<PlayerController>().TakeHit(attackDamage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DamageEnemy(collision);
            Destroy(gameObject);
        }
    }
}
