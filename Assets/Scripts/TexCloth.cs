using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TexCloth : MonoBehaviour {
	public int ReqC=0;
	// Use this for initialization
	void Start () {
		ReqC=UnityEngine.Random.Range(1,11);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public int ReturnReqC(){
		return ReqC;
	}
	public void NewReqC(){
		ReqC=UnityEngine.Random.Range(1,11);
	}
}
