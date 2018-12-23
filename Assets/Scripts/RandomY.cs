using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomY : MonoBehaviour
{
    public float minY;
    public float maxY;

	void Start ()
    {
        GetComponent<Transform>().position = new Vector3(this.transform.position.x, Random.Range(minY, maxY), this.transform.position.z);
	}
}
