using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemygenerator : MonoBehaviour
{
    public GameObject Slime;
    public GameObject Turtle;

    float EnemyHeight = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Slime, new Vector3(100, EnemyHeight, 100), transform.rotation);
        Instantiate(Slime, new Vector3(-40, EnemyHeight, -100), transform.rotation);

        Instantiate(Turtle, new Vector3(50, EnemyHeight, 120), transform.rotation);
        Instantiate(Turtle, new Vector3(-20, EnemyHeight, -40), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
