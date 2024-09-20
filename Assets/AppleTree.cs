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
    public float bombChance = 0.55f;


    void Start()
    {
        // Start dropping apples
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        if (Random.value > bombChance)
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
            Invoke("DropApple", appleDropDelay);
        }
        else
        {
            GameObject bomb = Instantiate<GameObject>(bombPrefab);
            bomb.transform.position = transform.position;
            Invoke("DropApple", appleDropDelay);
        }
        
    }

    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            
            speed *= -1; // Change direction
        }
    }
}
