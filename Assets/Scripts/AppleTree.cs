using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject applePrefab;
    public GameObject bombPrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;
    public float bombDropChance = 0.1f;
    public bool pause;

    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        if (pause) return;
        if (Random.value < bombDropChance)
        {
            GameObject bomb = Instantiate<GameObject>(bombPrefab);
            bomb.transform.position = transform.position;
            Invoke("DropApple", appleDropDelay);
        }
        else
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
            Invoke("DropApple", appleDropDelay);
        }
    }

    void Update()
    {
        if (!pause)
        {
            StandardMove();
        }
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }

    void StandardMove()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }
}

