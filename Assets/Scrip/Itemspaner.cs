using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemspaner : MonoBehaviour {

    public GameObject[] items;
    Vector2 position;
    //public static float cad;
    int itemsNO;
    public float maxPoa = 18.4f;
    public float delayTimer = 1f;
    float timer;
    // Use this for initialization
    void Start()
    {
        timer = delayTimer;
        //cad = position.y;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 itemsPoa = new Vector3(Random.Range(-18.4f, 18.4f), transform.position.y, transform.position.z);
            itemsNO = Random.Range(0, 7);
            Instantiate(items[itemsNO], itemsPoa, transform.rotation);
            timer = delayTimer;
        }
    }
}
