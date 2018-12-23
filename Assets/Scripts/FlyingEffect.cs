using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEffect : MonoBehaviour
{
    private ParticleSystem p;

	// Use this for initialization
	void Start ()
    {
        p = transform.GetChild(1).GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 velocity = this.GetComponent<Rigidbody>().velocity;
        //Debug.Log(velocity.magnitude);
   
        float speed = velocity.magnitude;
        
        if(speed > 1.0f)
        {

            var emission = p.emission;
            emission.enabled = true;
            var main = p.main;
            main.simulationSpeed = speed * 0.1f;
            //108 for more rounded to 50 for stretched
            ParticleSystemRenderer renderer = p.GetComponent<ParticleSystemRenderer>();
            renderer.lengthScale = Mathf.Lerp(108.0f, 50.0f, speed / 60.0f);


        }
        else
        {
            var emission = p.emission;
            emission.enabled = false;

            p.Clear();
        }
    }
}
