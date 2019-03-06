using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

    public GameObject door;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            Debug.Log("triggered");
            door.transform.rotation = Quaternion.Euler(0f, 270, 0f);
            door.transform.position = new Vector3(-13.9f, 2.079f, 9.8f);
        }

    }
}
