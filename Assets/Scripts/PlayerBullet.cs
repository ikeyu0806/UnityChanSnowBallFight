using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float shotSpeed = 10f;
    GameObject shotPoint;
    GameObject Player;
    enum Direction { Up, Down, Right, Left };
    Direction shotDirection;

    private void Start()
    {
        shotPoint = GameObject.FindWithTag("shotPoint");
        Player = GameObject.FindWithTag("Player");
        //Debug.Log("XXX");
        //Debug.Log(shotPoint.transform.position.z);
        //Debug.Log(Player.transform.position.z);
        //Debug.Log("ZZZ");
        //Debug.Log(shotPoint.transform.position.x);
        //Debug.Log(Player.transform.position.x);
        if ((int)shotPoint.transform.position.z > (int)Player.transform.position.z)
        {
            shotDirection = Direction.Up;
        }
        else if ((int)shotPoint.transform.position.z < (int)Player.transform.position.z)
        {
            shotDirection = Direction.Down;
        }
        else if ((int)shotPoint.transform.position.x > (int)Player.transform.position.x)
        {
            shotDirection = Direction.Right;
        }
        else if ((int)shotPoint.transform.position.x < (int)Player.transform.position.x)
        {
            shotDirection = Direction.Left;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(shotDirection)
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
}
