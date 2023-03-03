using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohesionBehaviour : Steering
{
    public Transform[] targets;
    [SerializeField] private float viewAngle = 60f;

    private GameObject sun;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringBase){
        SteeringData steering = new SteeringData();
        sun = GameObject.FindGameObjectWithTag("Sun");
        if (sun.transform.position.y < 0.5){
            SetWeight(0f);
        }
        else SetWeight(1.5f);
        Vector3 centerOfMass = Vector3.zero;
        int count = 0;
        foreach (Transform target in targets){
            Vector3 targetDir = target.position - transform.position;
            if (Vector3.Angle(targetDir, transform.forward) < viewAngle){
                centerOfMass += target.position;
                count ++;
            }
        }
        if (count > 0){
            centerOfMass = centerOfMass / count;
            steering.linear = centerOfMass - transform.position;
            steering.linear.Normalize();
            steering.linear *= steeringBase.maxAcceleration;
        }

        if (sun.transform.position.y > 2 && sun.transform.position.y < 6)
            SetWeight(0);
        return steering;
    }
}