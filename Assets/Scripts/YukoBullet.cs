using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukoBullet : MonoBehaviour
{
    float shotSpeed = 10f;
    int attackDamage = 10;

    GameObject YukoModel;
    GameObject Player;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        YukoModel = GameObject.Find("EnemyYuko");
        Player = GameObject.Find("Player");

        transform.LookAt(Player.transform);

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * shotSpeed;
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
