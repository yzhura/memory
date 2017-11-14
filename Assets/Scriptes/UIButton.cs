using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


public class UIButton : MonoBehaviour {

	[SerializeField] private GameObject targetObject;
	[SerializeField] private string targetMessage;
	public GameObject m_on, m_off;

	void Start (){
		if (gameObject.name == "Volume"){
			if (PlayerPrefs.GetString ("Music") == "no") {
				m_on.SetActive (false);
				m_off.SetActive (true);
			} else {
				m_on.SetActive (true);
				m_off.SetActive (false);
			}
		}
	}



	void OnMouseUpAsButton(){

		if (PlayerPrefs.GetString("Music") != "no")
			GameObject.Find("ClickAudio").GetComponent<AudioSource> ().Play ();
		

		switch (targetMessage) {


		case "Help":
			SceneManager.LoadScene ("Help");
			break;

		case "Rate":
			Application.OpenURL("https://play.google.com/store/apps/details?id=com.yza.memory");
			break;

		case "Masha":
			SceneManager.LoadScene ("Masha");
			break;

		case "AmNyam":
			
			SceneManager.LoadScene ("AmNyam");
			break;

		case "Cars":
			
			SceneManager.LoadScene("Cars");
				break;

		case "Fruits":
			SceneManager.LoadScene("Fruits");
			break;

		case "Fixik":
			SceneManager.LoadScene("Fixik");
			break;
		case "exit":
			SceneManager.LoadScene("Menu");
			break;

		case "repeat":
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			break;

		case "ads":
			if (Advertisement.isSupported) {
				Advertisement.Initialize ("1542017", false);
			} else {
				Debug.Log ("Nooooo");
			}
			if (Advertisement.IsReady ()) {
				Advertisement.Show ();

			}
			break;

		case "Music":
			if (PlayerPrefs.GetString ("Music") != "no") {
				PlayerPrefs.SetString ("Music", "no");
				m_on.SetActive (false);
				m_off.SetActive (true);
			}
			else {
				PlayerPrefs.SetString ("Music", "yes");
				m_on.SetActive (true);
				m_off.SetActive (false);
			}
				
			break;


		}
			
	}
		

	void Update () {
		
	}
		
}
