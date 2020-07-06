using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TurnSystem : MonoBehaviour {

	private List<CharacterStats> unitsStats;

	private GameObject playerParty;

	public GameObject enemyEncounter;

	[SerializeField]
	private GameObject actionsMenu, enemyUnitsMenu;

	void Start() {
		this.playerParty = GameObject.Find ("PlayerParty");

		unitsStats = new List<CharacterStats> ();
		GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
		foreach (GameObject playerUnit in playerUnits) {
			PlayerStats currentUnitStats = playerUnit.GetComponent<PlayerStats> ();
			currentUnitStats.calculateNextActTurn (0);
			unitsStats.Add (currentUnitStats);
			
		}
		GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
		foreach (GameObject enemyUnit in enemyUnits) {
			CharacterStats currentUnitStats = enemyUnit.GetComponent<CharacterStats> ();
			currentUnitStats.calculateNextActTurn (0);
			unitsStats.Add (currentUnitStats);			
		}
		unitsStats.Sort ();

		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (false);

		this.nextTurn ();
	}

	public void nextTurn() {
		GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag ("EnemyUnit");
		if (remainingEnemyUnits.Length == 0) {
			this.enemyEncounter.GetComponent<CollectReward> ().collectReward ();
			SceneManager.LoadScene ("Macael");
		}

		GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		if (remainingPlayerUnits.Length == 0) {
			SceneManager.LoadScene("Menu");
		}

		CharacterStats currentUnitStats = unitsStats [0];
		unitsStats.Remove (currentUnitStats);

		if (!currentUnitStats.isDead ()) {
			GameObject currentUnit = currentUnitStats.gameObject;

			currentUnitStats.calculateNextActTurn (currentUnitStats.nextActTurn);
			unitsStats.Add (currentUnitStats);
			unitsStats.Sort ();

			if (currentUnit.tag == "PlayerUnit") {
				this.playerParty.GetComponent<SelectUnit> ().selectCurrentUnit (currentUnit.gameObject);
			} else {
				currentUnit.GetComponent<EnemyUnitAction> ().act ();
			}
		} else {
			this.nextTurn ();
		}
	}
}