using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukoBullet : MonoBehaviour
{
    float shotSpeed = 10f;
    int attackDamage = 10;

    GameObject YukoModel;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        YukoModel = GameObject.Find("EnemyYuko");
        Player = GameObject.Find("Player");

        transform.LookAt(Player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * shotSpeed;
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
        }
        Destroy(gameObject);
    }
}
