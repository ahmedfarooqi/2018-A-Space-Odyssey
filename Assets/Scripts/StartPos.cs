using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int x=UnityEngine.Random.Range(-1400, 2709);
		int y=UnityEngine.Random.Range(-477, 485);
		int z=UnityEngine.Random.Range(-1611, 593);
		this.transform.position = new Vector3 (x,y,z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
