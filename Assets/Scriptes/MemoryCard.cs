using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour {


	[SerializeField] private GameObject cardBack; //Переменная, которая появляется на панели Inspector
	[SerializeField] private SceneController controller; 
	private int _id;

	public int id {
		get { return _id;} //Добавление фун-ции чтения (метод гэт и сэт)
	}

	//Открытый метод, которым могут пользоваться другие сценарии для передачи указанному объекту новых спрайтов.
	public void SetCard (int id, Sprite image) {
		_id = id;
		GetComponent<SpriteRenderer> ().sprite = image;  //Сопоставляем этот спрайт компоненту SpriteRenderer.
	}

	// Эта функция вызывается после щелчка на объекте.
	public void OnMouseDown(){ 
		if (cardBack.activeSelf && controller.canReveal) //Проверка свойства canReveal контроллера, позволяющая гарантировать, что одновременно могут быть открыты всего две карты.
		{
			cardBack.SetActive (false); //Карта становится видимой/невидимой
			controller.CardRevealed(this); //Уведомление контроллера при открытии этой карты.
		}
	}

	//Открытый метод, позволяющий компоненту SceneController снова скрыть карту (вернув на место спрайт card_back).
	public void Unreveal (){
		cardBack.SetActive (true);
	}

	void Start () {
		
	}
	

	void Update () {
		
	}
}
