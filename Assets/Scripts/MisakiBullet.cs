using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisakiBullet : MonoBehaviour
{
    float shotSpeed = 10f;
    int attackDamage = 10;

    GameObject MisakiModel;
    GameObject Player;

    private float dist;

    // Start is called before the first frame update
    void Start()
    {
        MisakiModel = GameObject.Find("EnemyMisaki");
        Player = GameObject.Find("Player");

        transform.LookAt(Player.transform);

        dist = Vector3.Distance(Player.transform.position, transform.position);
        Debug.Log(dist);
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
