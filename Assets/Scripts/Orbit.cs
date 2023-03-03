using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //public double theta;

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < 0){
            this.transform.RotateAround(Vector3.zero, Vector3.right, 0.3f);
        }
        else this.transform.RotateAround(Vector3.zero, Vector3.right, 0.05f);
    }
}
