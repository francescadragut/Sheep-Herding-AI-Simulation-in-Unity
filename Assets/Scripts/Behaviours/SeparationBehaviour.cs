using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparationBehaviour : Steering
{
    public Transform[] targets;
    [SerializeField] private float threshold = 2f;
    [SerializeField] private float decayCoefficient = -25f;

    private GameObject sun;

    public override SteeringData GetSteering(SteeringBehaviorBase steeringBase){
        SteeringData steering = new SteeringData();
        sun = GameObject.FindGameObjectWithTag("Sun");
        if (sun.transform.position.y < 1){
            SetWeight(0f);
        }
        else if (sun.transform.position.y > 2 && sun.transform.position.y < 6)
            SetWeight(0);
        else SetWeight(2f);
        foreach (Transform target in targets){
            Vector3 direction = target.transform.position - transform.position;
            float distance = direction.magnitude;
            if (distance < threshold){
                float strength = Mathf.Min(decayCoefficient / (distance * distance), steeringBase.maxAcceleration);
                direction.Normalize();
                steering.linear += strength * direction;
            }
        }
        
        return steering;
    }
}
