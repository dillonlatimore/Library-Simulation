using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointScript : MonoBehaviour {

    public GameObject hud;
    public GameObject hudMarker;
    public GameObject target1;
    public GameObject target2;
    public GameObject currentTarget;
    public GameObject groundLine1;
    public GameObject groundLine2;

    private Camera cam;

    private GameObject wp;

	// Use this for initialization
	void Start () {
        currentTarget = target1;
        cam = GetComponentInChildren<Camera>();

        wp = Instantiate(hudMarker);
        wp.GetComponent<RectTransform>().SetParent(hud.transform);

        groundLine2.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        float check = Vector3.Dot((currentTarget.transform.position - cam.transform.position).normalized,
            cam.transform.forward);
        if(check <= 0f)
        {
            wp.GetComponent<RawImage>().enabled = false;
        } else
        {
            wp.GetComponent<RawImage>().enabled = true;
            wp.GetComponent<RectTransform>().position = cam.WorldToScreenPoint(
                new Vector3(currentTarget.transform.position.x, currentTarget.transform.position.y + 
                currentTarget.transform.lossyScale.y, currentTarget.transform.position.z));
        }
        
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Target 1")
        {
            Debug.Log("triggered");
            currentTarget = target2;
            groundLine1.SetActive(false);
            groundLine2.SetActive(true);
        }
        
    }
}
