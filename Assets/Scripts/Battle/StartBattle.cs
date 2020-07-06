using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartBattle : MonoBehaviour {

	public static StartBattle instance = null;

	// Use this for initialization
	void Start () {
		
		if(instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad (gameObject);
		SceneManager.sceneLoaded += OnSceneLoaded;	
		this.gameObject.SetActive (true);
	}



	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "Menu") {
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy (this.gameObject);
		} 
	}

}
