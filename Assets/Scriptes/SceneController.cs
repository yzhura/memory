using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour {



	public const int gridRows = 2; // значения, количество ячеек и расстояние между ними
	public const int gridCols = 4;
	public const float offsetX = 3.7f;
	public const float offsetY = 4f;
	private int _score = 0;
	public Text textscore;
	private MemoryCard _firstRevealed; 
	private MemoryCard _secondRevealed;
	//68BD6FA4457C4E7CFBED5BB5BDC8CBA3
	[SerializeField] private GameObject panel;
	[SerializeField] private MemoryCard originalCard; // ссылка для карты в сцене
	[SerializeField] private Sprite [] images ; // массив для ссылок на ресурсы-спрайты

	void Start () {

		Vector3 startPos = originalCard.transform.position; // положение первой карты; положение других карт отсчитывается от этой точки

		int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 }; // объявление целочисленного массива с парами идентификаторов
		// для всех четырёх спрайтов с изображениями карт
		numbers = ShuffleArray(numbers);

		for (int i = 0; i < gridCols; i++) {    // циклы, задающие столбцы
			for (int j = 0; j < gridRows; j++) {  // и строки сетки
				MemoryCard card; // ссылка на контейнер для исходной карты и её копий
				if (i == 0 && j == 0) {
					card = originalCard;
				} else {
					card = Instantiate (originalCard) as MemoryCard;
				}

				int index = j * gridCols + i;
				int id = numbers [index]; // получение идентификаторов из перемешанного списка
				card.SetCard (id, images [id]);

				float posX = (offsetX * i) + startPos.x;
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3 (posX, posY, startPos.z); // в двухмерной графике значение оси Z не меняется
			}
		}
	}

	public bool canReveal {
		get {return _secondRevealed == null;} 
	}

	public void CardRevealed(MemoryCard card) {
		if (_firstRevealed == null) { 
			_firstRevealed = card;
		} else {
			_secondRevealed = card;
			StartCoroutine(CheckMatch());
		}
	}

	private IEnumerator CheckMatch() {
		if (_firstRevealed.id == _secondRevealed.id) {
			if (PlayerPrefs.GetString("Music") != "no")
				GameObject.Find("twocards").GetComponent<AudioSource> ().Play ();
			_score++;
			_score++;
			textscore.text = _score.ToString ("Счет: " + _score + " из 8");
		}
		else {
			yield return new WaitForSeconds(.5f);
			_firstRevealed.Unreveal (); 
			_secondRevealed.Unreveal ();
		}

		if (_score == 8) {
			yield return new WaitForSeconds(.5f);
			panel.SetActive (true);
			if (PlayerPrefs.GetString ("Music") != "no")
				panel.GetComponent<AudioSource> ().Play ();
		}
		_firstRevealed = null;
		_secondRevealed = null;
	}

	private int[] ShuffleArray (int[] numbers) { // реализация алгоритма тасования Кнута
		int[] newArray = numbers.Clone () as int[];
		for (int i = 0; i < newArray.Length; i++) {
			int tmp = newArray [i];
			int r = Random.Range (i, newArray.Length);
			newArray [i] = newArray [r];
			newArray [r] = tmp;
		}
		return newArray;
	}
	void Update (){
		
	/*	if (_score == 8) {
			
			panel.SetActive (true);
		}
	*/}
}