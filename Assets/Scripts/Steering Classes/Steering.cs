using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Steering : MonoBehaviour
{
    [SerializeField] private float weight = 1f;

    public abstract SteeringData GetSteering(SteeringBehaviorBase steeringBase);   

    public float GetWeight(){
        return weight;
    }

    public void SetWeight(float w){
        this.weight = w;
    }
}
