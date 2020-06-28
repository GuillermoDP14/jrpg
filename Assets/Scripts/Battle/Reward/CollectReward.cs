using UnityEngine;
using System.Collections;

public class CollectReward : MonoBehaviour {

	[SerializeField]
	private int experience;

	public void Start() {
		GameObject turnSystem = GameObject.Find ("TurnSystem");
		turnSystem.GetComponent<TurnSystem> ().enemyEncounter = this.gameObject;
	}

	public void collectReward() {
		GameObject[] livingPlayerUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		int experiencePerUnit = this.experience / livingPlayerUnits.Length;
		foreach (GameObject playerUnit in livingPlayerUnits) {
			playerUnit.GetComponent<PlayerStats> ().receiveExperience (experiencePerUnit);
		}

		Destroy (this.gameObject);
	}
}
