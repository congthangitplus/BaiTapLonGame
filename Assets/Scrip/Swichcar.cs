using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swichcar : MonoBehaviour {

    public GameObject car1;
    public GameObject car2;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switchdoixe();
        }
	}

    void switchdoixe()
    {
        if (car1.activeSelf)
        {
            car1.SetActive(false);
            car2.SetActive(true);
        }
        else
        {
            car1.SetActive(true);
            car2.SetActive(false);
        }
    }
}
