using UnityEngine;
using System.Collections;

public class AttackTarget : MonoBehaviour {

	public GameObject owner;

	[SerializeField]
	private string attackAnimation;

	[SerializeField]
	private bool magicAttack;

	[SerializeField]
	private int manaCost;

	[SerializeField]
	private float minAttackMultiplier;

	[SerializeField]
	private float maxAttackMultiplier;

	[SerializeField]
	private float minDefenseMultiplier;

	[SerializeField]
	private float maxDefenseMultiplier;
	
	public void hit(GameObject target) {
		CharacterStats ownerStats = this.owner.GetComponent<CharacterStats> ();
		CharacterStats targetStats = target.GetComponent<CharacterStats> ();
		if (ownerStats.CurrentMana >= this.manaCost) {
			float attackMultiplier = (Random.Range(1,6) * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
			float damage = (this.magicAttack) ? attackMultiplier * ownerStats.Magic : attackMultiplier * ownerStats.Damage;

			float defenseMultiplier = (Random.Range(1,6) * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
			damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.Armor));

			this.owner.GetComponent<Animator> ().Play (this.attackAnimation);

			targetStats.receiveDamage ((int) damage);

			ownerStats.CurrentMana -= (int) this.manaCost;

			
		}
	}
}
