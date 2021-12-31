using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemygenerator : MonoBehaviour
{
    public GameObject Slime;
    public GameObject Turtle;

    float EnemyHeight = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Slime, transform.position += new Vector3(10, EnemyHeight, 10), transform.rotation);
        Instantiate(Slime, transform.position += new Vector3(5, EnemyHeight, -10), transform.rotation);

        Instantiate(Turtle, transform.position += new Vector3(5, EnemyHeight, 12), transform.rotation);
        Instantiate(Turtle, transform.position += new Vector3(7, EnemyHeight, -4), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
