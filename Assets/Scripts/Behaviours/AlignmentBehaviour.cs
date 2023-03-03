using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentBehaviour : Steering
{
    public Transform[] targets;
    [SerializeField] private float alignDistance = 8f;

    private GameObject sun;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringBase){
        SteeringData steering = new SteeringData();
        sun = GameObject.FindGameObjectWithTag("Sun");
        if (sun.transform.position.y < 1){
            SetWeight(0f);
        }
        else if (sun.transform.position.y > 2 && sun.transform.position.y < 6){
            SetWeight(0);
        }
        else SetWeight(1f);
        steering.linear = Vector3.zero;
        int count = 0;
        foreach (Transform target in targets){
            Vector3 targetDir = target.position - transform.position;
            if (targetDir.magnitude < alignDistance){
                steering.linear += target.GetComponent<Rigidbody>().velocity;
                count ++;
            }
        }
        if (count > 0){
            steering.linear = steering.linear / count;
            if (steering.linear.magnitude > steeringBase.maxAcceleration){
                steering.linear = steering.linear.normalized * steeringBase.maxAcceleration;
            }
        }
        return steering;
    }
    
}
