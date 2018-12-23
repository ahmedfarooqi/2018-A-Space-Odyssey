using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensFlareScaling : MonoBehaviour
{
    public Camera mainCamera;
    private float startingDistance;
    private float startingBrightness;

	// Use this for initialization
	void Start ()
    {
		startingDistance = Vector3.Distance(this.transform.position, mainCamera.transform.position);
        startingBrightness = this.GetComponent<LensFlare>().brightness;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float dist = Mathf.Abs(Vector3.Distance(this.transform.position, mainCamera.transform.position) - startingDistance);
        float newBrightness = startingBrightness * dist * 0.002f;
        if(newBrightness < 0.8f)
        {
            this.GetComponent<LensFlare>().brightness = 0.8f;
        }
        else if(newBrightness > 2.0f)
        {
            this.GetComponent<LensFlare>().brightness = 1.5f;
        }
        else
        {
            this.GetComponent<LensFlare>().brightness = newBrightness;
        }
	}
}
