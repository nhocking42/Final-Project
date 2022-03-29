using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public float x;
    public float y;
    void Start()
    {
        x = Random.Range(-10,10);
        y = Random.Range(-5, 5);

        transform.position = new Vector2(x,y);
    }
}
