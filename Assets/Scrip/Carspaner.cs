using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carspaner : MonoBehaviour {

    public GameObject[] cars;
    Vector2 position;
    public static float cad;
    int carNO;
    public float maxPoa = 18.4f;
    public float delayTimer = 1f; 
    float timer;
  
    // Use this for initialization
    void Start () {
        timer = delayTimer;
        //cad = position.y;
    }
	
	// Update is called once per frame
	void Update () {
        
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 carPoa = new Vector3(Random.Range(-18.4f, 18.4f), transform.position.y, transform.position.z);
            carNO = Random.Range(0, 7);
            Instantiate(cars[carNO], carPoa, transform.rotation);
            timer = delayTimer;
        }
    }
   
 }
