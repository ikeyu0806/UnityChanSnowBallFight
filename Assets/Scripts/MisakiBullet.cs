using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisakiBullet : MonoBehaviour
{
    float shotSpeed = 10f;
    int attackDamage = 10;

    GameObject MisakiModel;
    GameObject Player;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        MisakiModel = GameObject.Find("EnemyMisaki");
        Player = GameObject.Find("Player");

        transform.LookAt(Player.transform);

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * shotSpeed;
        if (transform.position.x > 200 || transform.position.x < -200 || transform.position.z > 200 || transform.position.z < -200 || transform.position.y < 0.7)
        {
            Destroy(gameObject);
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
