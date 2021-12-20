using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovementScript : MonoBehaviour
{
    Rigidbody ourDrone;
    void Awake()        //similar to void setup
    {
        ourDrone = GetComponent<Rigidbody>();     //makes the drone rigit so it won't fly through other ridgit bodies like the surroundings
    }

    void FixedUpdate()      //like void loop or something similar
    {
        MovementUpDown();       //function that controles the height translation of the drone
        MovementForward();      //function that controles the forward/backward translation of the drone
        Rotation();             //function that controles the rotation of the drone around it's centre
        ClampingSpeedValues();  //function that limits the speed of the different translations and stops the drone after initializing a translation
        Swerve();               //function that controles the left/right translation of the drone

        ourDrone.AddRelativeForce(Vector3.up * upForce);        //makes the drone hover by adding a force upward equal to upForce, which can be found after void FixedUpdate()
        ourDrone.rotation = Quaternion.Euler(
                new Vector3(tiltAmountForward, currentYRotation, tiltAmountSideways)
            );
    }

    
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public float upForce;       //float that will receive a value in the next function which defines the translation of the height of the drone
    void MovementUpDown()       //function that controles the height translation of the drone
    {
        if(Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)        //correcting the upwardFroce when moving side to side
        {
            if(Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K))
            {
                ourDrone.velocity = ourDrone.velocity;
            }
            if(!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L))
            {
                ourDrone.velocity = new Vector3(ourDrone.velocity.x, Mathf.Lerp(ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);
                upForce = 281;
            }
            if(!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L))
            {
                ourDrone.velocity = new Vector3(ourDrone.velocity.x, Mathf.Lerp(ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);
                upForce = 110;
            }
            if(Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K))
            {
                upForce = 410;
            }
        }

        if(Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            upForce = 135;
        }

        if(Input.GetKey(KeyCode.I))     //this key (I) will move the drone up (can be changed)
        {
            upForce = 450;      //force upward in Newton applied to the drone to accelerate it upward
            if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
            {
                upForce = 500f;
            }
        }
        else if(Input.GetKey(KeyCode.K))    //this key (K) will move the drone down (can be changed)
        {
            upForce = -200;     //force downward (because it's negative) in Newton applied to the drone which makes it accelerate downward
        }
        else if(!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f) )       //in case that there is no input for the height translation/stationairy state of the drone
        {
            upForce = 98.1f;    //force upward in Newton applied to the drone to make it hover at it's current position. IMPORTANT to change this in relation to the weight assigned to the drone in unity using the fromula: upForce = M(of the drone) * 9.81
        }       //important to check this force, look up the comment above
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
    private float movementForwardSpeed = 500.0f;        //change this float to change the speed of the drone, the higher the number, the faster the drone goes (must be positive)
    private float tiltAmountForward = 0;                //tilt angle of the drone for moving forward in stationary mode (should stay at 0)
    private float tiltVelocityForward;                  //float used in the function below
    void MovementForward()      //function that controles the forward/backward translation of the drone
    {
        if(Input.GetAxis("Vertical") != 0)      //standard input from unity, relates to the keys W & S for translating vertically/forward
        {
            ourDrone.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * movementForwardSpeed);      //applies a force to the drone in the forward direction based on the key input value from W & S times the movement speed variable from above
            tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 20 * Input.GetAxis("Vertical"), ref tiltVelocityForward, 0.1f);     //makes the drone tilt in forward or backward when moving forward or backward and slowly return to 0 when stationairy. change the number of the second argument to change the tilt angle (must stay positive)
        }   //change the number in the second argument to change the angle of the drone moving forward (must be positive). change the number in the last argument to change the damping (speed of returning to stationary) (must stay positive)
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
    private float wantedYRotation;      //stores the desired rotation of the drone around it's centre (Y) axis
    public float currentYRotation;     //stores the current rotation of the drone around it's centre (Y) axis
    private float rotateAmountByKeys = 2.5f;    //changes the amount of rotation the drone makes around it's centre (Y) axis
    private float rotationYVelocity;    //stores the velocity of the drone's rotation around it's centre (Y) axis
    void Rotation()     //function that controles the rotation of the drone around it's centre
    {
        if(Input.GetKey(KeyCode.J))     //this key (J) will rotate the drone left around it's centre (Y) axis
        {
            wantedYRotation -= rotateAmountByKeys;
        }
        if (Input.GetKey(KeyCode.L))    //this key (L) will rotate the drone right around it's centre (Y) axis
        {
            wantedYRotation += rotateAmountByKeys;
        }

        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);   //rotates the drone according to the set variables and key input
    }       //change the number in the last argument to change the damping rate (must be positive)


    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
    private Vector3 velocityToSmoothDampToZero;
    void ClampingSpeedValues()      //function that limits the speed of the different translations and stops the drone after initializing a translation
    {
        if(Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));  //change the number in the last argument to change the decaleration rate (must be positive)
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));  //change the number in the last argument to change the decaleration rate (must be positive)
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));  //change the number in the last argument to change the decaleration rate (must be positive)
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            ourDrone.velocity = Vector3.SmoothDamp(ourDrone.velocity, Vector3.zero, ref velocityToSmoothDampToZero, 5f);  //change the number in the last argument to change the decaleration rate (must be positive)
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
    private float sideMovement = 300.0f;    //change this float to change the sideways speed of the drone, the higher the number, the faster the drone goes (must be positive)
    private float tiltAmountSideways;       //stores the tilt angle of the drone sideways for the function below
    private float tiltAmountVelocity;       //stores the tilt speed of the drone sideways for the function below
    void Swerve()       //function that controles the left/right translation of the drone
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)       //standard input from unity, relates to the keys A & D for translating left-right/sideways
        {
            ourDrone.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * sideMovement);      //applies a force to the drone in the sideways direction based on the key input value from A & D times the movement speed variable from above
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, -1 * 20 * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);      //makes the drone tilt in left or right when moving sideways and slowly return to 0 when stationairy. change the number of the second argument to change the tilt angle (must stay positive)
        }
        else
        {
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);      
        }
    }
}
