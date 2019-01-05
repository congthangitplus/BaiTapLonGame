using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMove : MonoBehaviour {

    public float speed = 5f;
    public Rigidbody2D r2;
    float timeEffect;
    float startTime;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        MoveBarrier();
    }

    void MoveBarrier()
    {
        transform.Translate(new Vector3(0, -5, 0) * (speed + CarsControll.TT1 + CarsControll.GT1) * Time.deltaTime);
    }

 
}
