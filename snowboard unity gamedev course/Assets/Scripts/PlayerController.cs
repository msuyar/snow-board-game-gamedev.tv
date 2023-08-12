using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    Rigidbody2D rb2d;
    [SerializeField] float speedBoost = 0.01f;
    [SerializeField] float startingSpeed = 15f;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        surfaceEffector2D.speed = startingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }
    public void DisableControls()
    {
        canMove = false;
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
    void RespondToBoost()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed += speedBoost;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed -= speedBoost;
        }
        if(surfaceEffector2D.speed > 30)
        {
            surfaceEffector2D.speed = 30f;
        }
        else if(surfaceEffector2D.speed < 0)
        {
            surfaceEffector2D.speed = 0;
        } 
    }
}
