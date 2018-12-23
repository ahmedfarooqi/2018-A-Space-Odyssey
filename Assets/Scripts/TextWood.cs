using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWood : MonoBehaviour {
	public int ReqW=0;

	// Use this for initialization
	void Start () {
		ReqW=UnityEngine.Random.Range(1,11);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public int ReturnReqW(){
		return ReqW;
	}
	public void NewReqW(){
		ReqW=UnityEngine.Random.Range(1,11);
	}
}
