using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorBase : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Steering[] steerings;
    public float maxAcceleration = 10f;
    public float maxAngularAcceleration = 3f;
    public float drag = 1f;

    private void Start() {
        
        rigidBody = GetComponent<Rigidbody>();
        steerings = GetComponents<Steering>();
        rigidBody.drag = drag;
    }

    private void FixedUpdate() {
        
        Vector3 acceleration = Vector3.zero;
        float rotation = 0f;
        foreach(Steering behavior in steerings){

            SteeringData steeringData = behavior.GetSteering(this);
            acceleration += steeringData.linear * behavior.GetWeight();
            rotation += steeringData.angular * behavior.GetWeight();
        }

        if(acceleration.magnitude > maxAcceleration){

            acceleration.Normalize();
            acceleration *= maxAcceleration;
        }

        rigidBody.AddForce(acceleration);
        if(rotation != 0)
            rigidBody.rotation = Quaternion.Euler(0,rotation,0);
    }
}
