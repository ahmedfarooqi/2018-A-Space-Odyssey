using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public GameObject planet;
    public float orbitSpeed;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        planet.transform.Rotate(new Vector3(0, orbitSpeed * Time.deltaTime, 0));
	}
}
