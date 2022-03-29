using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public int rotateSpeed;
    public bool isMoved;
    public Transform followedObject;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
        if (isMoved)
        {
            transform.position = followedObject.position;
        }
    }
}
