using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMenu : MonoBehaviour {

	[SerializeField] private GameObject cardFirst, cardSecond;
	public float speed, tilt;
	private Vector3 target = new Vector3 (-4.27f, 0, 0);


	public void SetCard (Sprite image) {
		
		GetComponent<SpriteRenderer> ().sprite = image;  //Сопоставляем этот спрайт компоненту SpriteRenderer.
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, target, Time.deltaTime * speed);
		if (transform.position == target && target.y != 0.1f)
			target.y = 0.1f;
		else if (transform.position == target && target.y == 0.1f)
			target.y = 1.39f;

		transform.Rotate (Vector3.up * tilt);
	}
}
