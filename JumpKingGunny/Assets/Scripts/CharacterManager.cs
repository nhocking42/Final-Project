using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private const int MaxForce = 50;

    public GameObject camera;
    public GameObject spawnPoint;
    public Rigidbody2D rg;
    public Animator ani;
    public SpriteRenderer sdr;

    public ForceBarManager forceBar;
    private float jumpForce;

    private bool isHolding;

    private double deviatedLevel = 0.01;
    private static float width = 3;

    public GameObject cornerBorder;
    public GameObject directionPoint;
    private Vector2 directionVector;
    private double cornerLevel;
    private float directionX;
    private float directionY;

    private float corner;

    public GameObject[] floorPosition;
    public int currentFloor;
    private const float limitedFloorHeight = 5.3f;

    private void Start()
    {
        isHolding = false;
        jumpForce = 0;
        forceBar.SetMaxForce(MaxForce);

        cornerLevel = 1.55;

        currentFloor = 0;

    }
    void Update()
    {
        Movement();
        RespawnEvent();
        DirectionControl();

        setCurrentFloor();
        camera.transform.position = new Vector3(floorPosition[currentFloor].transform.position.x, 
                                                floorPosition[currentFloor].transform.position.y,
                                                -10);
    }

    public void setCurrentFloor()
    {
        while (transform.position.y > floorPosition[currentFloor].transform.position.y + limitedFloorHeight)
        {
            currentFloor++;
        }
        while (transform.position.y < floorPosition[currentFloor].transform.position.y - limitedFloorHeight)
        {
            currentFloor--;
        }
    }
    
    private void Movement()
    {

        if (Input.GetKeyDown(KeyCode.Space) && rg.velocity == Vector2.zero)
        {
            isHolding = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            
            isHolding = false;
        }

        if (isHolding)
        {
            ani.SetBool("isHold", true);
            jumpForce += 0.5f;
            if (jumpForce > MaxForce)
            {
                jumpForce = MaxForce;
            }
        }
        else
        {
            ani.SetBool("isHold", false);
            rg.AddForce(directionVector * jumpForce * 3);
            jumpForce = 0;
        }
        forceBar.SetForce((int)jumpForce);

        if (Input.GetKey(KeyCode.LeftArrow) && isTouchingLeftLimited() == false)
        {
            cornerLevel += deviatedLevel;
        }
        if (Input.GetKey(KeyCode.RightArrow) && isTouchingRightLimited() == false)
        {
            cornerLevel -= deviatedLevel;
        }

        if (rg.velocity.y <= 0)
        {
            ani.SetBool("isFalling", true);
        }
    }

    private void DirectionControl()
    {
        if (rg.velocity != Vector2.zero)
        {
            directionPoint.SetActive(false);
            cornerBorder.SetActive(false);
        }
        else
        {
            directionPoint.SetActive(true);
            cornerBorder.SetActive(true);
            ani.SetBool("isFalling", false)
                ;
        }

        corner = Vector2.Angle(Vector2.up, directionVector);
        if (directionPoint.transform.position.x > transform.position.x)
        {
            directionPoint.transform.rotation = Quaternion.Euler(0, 0, -corner);
            sdr.flipX = false;
        }
        else
        {
            directionPoint.transform.rotation = Quaternion.Euler(0, 0, corner);
            sdr.flipX = true;
        }

        directionX = (float)(Mathf.Cos((float)cornerLevel) * width + transform.position.x);
        directionY = (float)(Mathf.Sin((float)cornerLevel) * width + transform.position.y);

        directionPoint.transform.position = new Vector2(directionX, directionY);
        directionVector = directionPoint.transform.position - transform.position;
    }

    public void RespawnEvent()
    {
        if (transform.position.y < -10 || transform.position.x < -11 || transform.position.x > 11)
        {
            transform.position = spawnPoint.transform.position;
            rg.velocity = Vector2.zero;
        }
        
    }

    private bool isTouchingLeftLimited()
    {
        if (corner >= 90 && directionPoint.transform.position.x < transform.position.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool isTouchingRightLimited()
    {
        if (corner >= 90 && directionPoint.transform.position.x > transform.position.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



}
