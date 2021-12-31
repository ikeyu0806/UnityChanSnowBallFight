using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject Player;
    int attackDamage = 10;
    int enemyHP = 20;
    int score = 100;

    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer()
    {
        if (Player != null)
        {
            Player.GetComponent<PlayerController>().TakeHit(attackDamage);
        }
    }

    public void TakeHit(float damage)
    {
        enemyHP = (int)Mathf.Clamp(enemyHP - damage, 0, enemyHP);

        if (enemyHP <= 0)
        {
            Dead();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            DamagePlayer();
        }
    }

    public void Dead()
    {
        gameController.AddScore(score);
        Destroy(gameObject);
    }
}
