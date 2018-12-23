using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour
{
    public float minScaleFactor;
    public float maxScaleFactor;

	void Start ()
    {
        float scale = Random.Range(minScaleFactor, maxScaleFactor);
        GetComponent<Transform>().localScale = new Vector3(scale,scale,scale);
	}
}
