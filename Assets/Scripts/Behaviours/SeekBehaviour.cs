using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehaviour : Steering
{
 
    private GameObject target;
    private GameObject sun;
 

    public override SteeringData GetSteering(SteeringBehaviorBase steeringBase){
        
        SteeringData steering = new SteeringData();
        sun = GameObject.FindGameObjectWithTag("Sun");
        
        if (sun.transform.position.y < 1){
            SetWeight(2f);
            target = GameObject.FindGameObjectWithTag("Shepherd");
            steering.linear = target.transform.position - transform.position;
            steering.linear.Normalize();
            steering.linear *= steeringBase.maxAcceleration;
            steering.angular = 0;
        }
        else if (sun.transform.position.y > 2 && sun.transform.position.y < 6){
            SetWeight(2f);
            
            target = GameObject.FindGameObjectWithTag("Feeding");

            steering.linear = target.transform.position - transform.position;
            steering.linear.Normalize();
            steering.linear *= steeringBase.maxAcceleration;
            steering.angular = 0;
        }
        
        return steering;
    }
}
