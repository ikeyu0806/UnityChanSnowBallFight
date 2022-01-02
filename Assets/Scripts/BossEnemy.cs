using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    Animator animator;
    private float time;
    public GameObject bulletPrefab;
    public Transform shotPoint;

    public enum Direction { Up, Down, Right, Left };
    public Direction bossDirection;

    float shotHeight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        shotPoint.position = shotPoint.position + new Vector3(0f, shotHeight, -0.5f);
        time = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Throw();
    }

    void Throw()
    {
        if (time >= 1.0f)
        {
            //animator.SetBool("Throw", true);
            Invoke(nameof(ShotSnow), 1f);
            time = 0.0f;
        }
    }

    void ShotSnow()
    {
        Instantiate(bulletPrefab, shotPoint.position, transform.rotation);
    }
}
