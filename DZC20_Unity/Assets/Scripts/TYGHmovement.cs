using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TYGHmovement : MonoBehaviour
{
    Rigidbody ourDrone;
    void Awake()
    {
        ourDrone = GetComponent<Rigidbody>();     //makes the drone rigit so it won't fly through other ridgit bodies like the surroundings
        droneSound = gameObject.transform.Find("Drone_sound").GetComponent<AudioSource>();
        
        //Get the Renderer component from the new cube
        //var TRenderer = RotorT.GetComponent<Material>();        
    }

    //public float droneMass = ourDrone.GetComponent<Rigidbody>().Mass;
    public float movementSpeed = 100.0f;
    private float PropSpeed = 200;
    private float PropSpeedIncrease = 4;
    public float upForce;
    public float movementY;
    private float movementX;
    private int rotationDirection;
    private int NumberOfRotorsActive;
    public GameObject RotorT;
    public GameObject RotorY;
    public GameObject RotorG;
    public GameObject RotorH;

    void FixedUpdate()
    {
        movementY = 0;
        movementX = 0;
        rotationDirection = 0;
        NumberOfRotorsActive = 0;

        checkT();
        checkY();
        checkG();
        checkH();

        MovementForwardBackward();
        Swerve();
        MovementUp();
        Rotation();
        DroneSound();

        ourDrone.AddRelativeForce(Vector3.up * upForce);
        ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 1f, Time.deltaTime * 5f));
        ourDrone.rotation = Quaternion.Euler(
                new Vector3(tiltAmountForward, currentYRotation, tiltAmountSideways)
            );
    }

    void checkT()
    {
        if (Input.GetKey(KeyCode.T)) //(1,-1)
        {
            movementX += 1;
            movementY -= 1;
            rotationDirection += 1;
            NumberOfRotorsActive += 1;
            RotorT.transform.Rotate(0f, PropSpeedIncrease * PropSpeed * Time.fixedDeltaTime, 0f, Space.Self);
            //RotorT.color = Color.blue;
        }
        else  {
            RotorT.transform.Rotate(0f, PropSpeed * Time.fixedDeltaTime, 0f, Space.Self);
        }
    }

    void checkY()
    {
        if (Input.GetKey(KeyCode.U)) //(-1,-1)
        {
            movementX -= 1;
            movementY -= 1;
            rotationDirection -= 1; ;
            NumberOfRotorsActive += 1;
            RotorY.transform.Rotate(0f, -1 * PropSpeedIncrease * PropSpeed * Time.fixedDeltaTime, 0f, Space.Self);
        }
        else {
            RotorY.transform.Rotate(0f, -1 * PropSpeed * Time.fixedDeltaTime, 0f, Space.Self);
        }
    }

    void checkG()
    {
        if (Input.GetKey(KeyCode.G)) //(1,1)
        {
            movementX += 1;
            movementY += 1;
            rotationDirection -= 1; ;
            NumberOfRotorsActive += 1;
            RotorG.transform.Rotate(0f, PropSpeedIncrease * -1 * PropSpeed * Time.fixedDeltaTime, 0f, Space.Self);
        }
        else {
            RotorG.transform.Rotate(0f, -1 * PropSpeed * Time.fixedDeltaTime, 0f, Space.Self);
        }
    }

    void checkH()
    {
        if (Input.GetKey(KeyCode.J)) //(-1,1)
        {
            movementX -= 1;
            movementY += 1;
            rotationDirection += 1; ;
            NumberOfRotorsActive += 1;
            RotorH.transform.Rotate(0f, PropSpeedIncrease * PropSpeed * Time.fixedDeltaTime, 0f, Space.Self);
        }
        else {
            RotorH.transform.Rotate(0f, PropSpeed * Time.fixedDeltaTime, 0f, Space.Self);
        }
    }

    private float tiltAmountForward = 0;
    private float tiltVelocityForward;
    
    void MovementForwardBackward()
    {
        ourDrone.AddRelativeForce(Vector3.forward * movementSpeed * movementY);
        tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 20 * movementY, ref tiltVelocityForward, 0.1f);     //makes the drone tilt in forward or backward when moving forward or backward and slowly return to 0 when stationairy. change the number of the second argument to change the tilt angle (must stay positive)

    }

    private float tiltAmountSideways;
    private float tiltAmountVelocity;
    void Swerve()
    {
        ourDrone.AddRelativeForce(Vector3.right * movementSpeed * movementX);
        tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, -1 * 20 * movementX, ref tiltAmountVelocity, 0.1f);
    }

    private float wantedYRotation;
    public float currentYRotation;
    private float rotateAmountByKeys = 2.5f;
    private float rotationYVelocity;
    void Rotation ()
    {
        switch (rotationDirection)
        {
            case 2:
                wantedYRotation += rotateAmountByKeys;
                upForce = 98.1f;
                break;
            case -2:
                wantedYRotation -= rotateAmountByKeys;
                upForce = 98.1f;
                break;
        }
        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
    }

    void MovementUp()
    {
        switch (NumberOfRotorsActive)
        {
            case 0:
                upForce = 98f;
                break;
            case 1:
                upForce = 140f;
                break;
            case 2:
                ourDrone.velocity = new Vector3(ourDrone.velocity.x, Mathf.Lerp(ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);
                upForce = 190f;
                break;
            case 3:
                upForce = 135f;
                break;
            case 4:
                upForce = 250f;
                break;
        }
    }

    private AudioSource droneSound;
    void DroneSound()
    {
        droneSound.pitch = 1 + (ourDrone.velocity.magnitude / 10);
    }
}
