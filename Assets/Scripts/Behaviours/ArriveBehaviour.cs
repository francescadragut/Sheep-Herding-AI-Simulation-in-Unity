using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveBehaviour : Steering
{

    private Transform target;

    [SerializeField]
    float targetRadius = 0.5f;
    [SerializeField]
    float slowRadius = 5f;

    [SerializeField]
    float maxPrediction = 2f;

    private GameObject sun;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringBase){
        SteeringData steering = new SteeringData();
        sun = GameObject.FindGameObjectWithTag("Sun");

        float initialTime = 0;

        if (sun.transform.position.y < 1){
            SetWeight(2f);
            target = GameObject.FindGameObjectWithTag("Shepherd").transform;
            
            Vector3 direction = target.position - transform.position;
            float distance = direction.magnitude;
            if(distance < targetRadius){

                steeringBase.GetComponent<Rigidbody>().velocity = Vector3.zero;
                return steering;
            }

            float targetSpeed;
            if(distance > slowRadius)
                targetSpeed = steeringBase.maxAcceleration;
            else
                targetSpeed = steeringBase.maxAcceleration * (distance / slowRadius);

            Vector3 targetVelocity = direction;
            targetVelocity.Normalize();
            targetVelocity *= targetSpeed;
            steering.linear = targetVelocity - steeringBase.GetComponent<Rigidbody>().velocity;
            if(steering.linear.magnitude > steeringBase.maxAcceleration){

                steering.linear.Normalize();
                steering.linear *= steeringBase.maxAcceleration;
            }
            steering.angular = 0;
        }
        else if (sun.transform.position.y > 2 && sun.transform.position.y < 6){
            SetWeight(2f);
            
            target = GameObject.FindGameObjectWithTag("Feeding").transform;
            
            Vector3 direction = target.position - transform.position;
            float distance = direction.magnitude;
            if(distance < targetRadius){

                steeringBase.GetComponent<Rigidbody>().velocity = Vector3.zero;
                return steering;
            }

            float targetSpeed;
            if(distance > slowRadius)
                targetSpeed = steeringBase.maxAcceleration;
            else
                targetSpeed = steeringBase.maxAcceleration * (distance / slowRadius);

            Vector3 targetVelocity = direction;
            targetVelocity.Normalize();
            targetVelocity *= targetSpeed;
            steering.linear = targetVelocity - steeringBase.GetComponent<Rigidbody>().velocity;
            if(steering.linear.magnitude > steeringBase.maxAcceleration){

                steering.linear.Normalize();
                steering.linear *= steeringBase.maxAcceleration;
            }
            steering.angular = 0;
        }
        
     
        
        return steering;
        
    }
}
