using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject mainCharacter;
    private int floor;
    public const float limitedFloorHeight = 5.7f;
    void Start()
    {
        floor = 1;   
    }

    void Update()
    {
        if (mainCharacter.transform.position.y < limitedFloorHeight)
        {
            floor = 1;
        }
        if (mainCharacter.transform.position.y > limitedFloorHeight)
        {
            floor = 2;
        }
        upFloor();
    }

    private void upFloor()
    {
        switch (floor)
        {
            case 1:
                transform.position = new Vector3(0,0,-10);
                break;
            case 2:
                transform.position = new Vector3(transform.position.x, limitedFloorHeight * floor, -10);
                break;

        }
    }
}
