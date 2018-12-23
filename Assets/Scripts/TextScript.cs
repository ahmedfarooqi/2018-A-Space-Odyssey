using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {
	//public Text scoreT;
	public int Score=0;
	public int Score_Wood=0;
	public int Score_Metal=0;
	public int Score_Cloth=0;
	// Use this for initialization
	void Start () {
		//scoreT.text = "Score: " + Score + "\n" + "Wood: "+ Score_Wood + "\n" + "Metal: " + Score_Metal + "\n" + "Cloth: " + Score_Cloth;
	}
	
	// Update is called once per frame
	void Update () {
		//scoreT.text = "Score: " + Score + "\n" + "Wood: "+ Score_Wood + "\n" + "Metal: " + Score_Metal + "\n" + "Cloth: " + Score_Cloth;
	}

	public void UpdateScore(int offset){
		Score+=offset;
	}

	public void UpdateWood(int offset){
		Score_Wood+=offset;
	}

	public void UpdateMetal(int offset){
		Score_Metal+=offset;
	}

	public void UpdateCloth(int offset){
		Score_Cloth+=offset;
	}

	public int ReturnWood(){
		return Score_Wood;
	}

	public int ReturnMetal(){
		return Score_Metal;
	}
	public int ReturnCloth(){
		return Score_Cloth;
	}
	
}
