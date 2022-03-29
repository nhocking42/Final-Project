using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovedTerrain : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;

    public int movementType;
    // 0: normal (A to B and B back to A)
    // 1: One way (A to B and teleport to A) (Only with 2 points)
    // 2: Rotate

    private int i;

    private void Start()
    {
        transform.position = points[startingPoint].position;
    }

    private void Update()
    {
        if (movementType == 0)
        {
            normalMovement();
        }
        if (movementType == 1 && points.Length == 2)
        {
            oneWayMovement();
        }

    }

    public void oneWayMovement()
    {
        if (Vector2.Distance(transform.position, points[1].position) < 0.02f)
        {
            transform.position = points[0].position;
        }
        transform.position = Vector2.MoveTowards(transform.position, points[1].position, speed * Time.deltaTime);
    }
    public void normalMovement()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }


}
 