using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject mainCharacter;
    public GameObject[] floorPosition;
    private int currentFloor;
    public const float limitedFloorHeight = 5.3f;
    void Start()
    {
        currentFloor = 0;   
    }

    void Update()
    {

        if (mainCharacter.transform.position.y > getFloorTopLimited(currentFloor))
        {
            currentFloor++;
        }
        if (mainCharacter.transform.position.y < getFloorBottomLimited(currentFloor) && currentFloor > 0)
        {
            currentFloor--;
        }
        transform.position = floorPosition[currentFloor].transform.position;
    }

    private float getFloorTopLimited(int floor)
    {
        return floorPosition[floor].transform.position.y + limitedFloorHeight;
    }
    private float getFloorBottomLimited(int floor)
    {
        return floorPosition[floor].transform.position.y - limitedFloorHeight;
    }
}
