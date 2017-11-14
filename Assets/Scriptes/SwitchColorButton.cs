using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwitchColorButton : MonoBehaviour {
	

	public Sprite layer_red, layer_green;

	void OnMouseDown (){
		GetComponent<SpriteRenderer> ().sprite = layer_green;
	}

	void OnMouseUp (){
		GetComponent<SpriteRenderer> ().sprite = layer_red;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
