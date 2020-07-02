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


	
	public void hit(GameObject target) {
		CharacterStats ownerStats = this.owner.GetComponent<CharacterStats> ();
		CharacterStats targetStats = target.GetComponent<CharacterStats> ();
		float damage, attackPower = 0;
		if (ownerStats.CurrentMana >= this.manaCost) {
			
			if(this.manaCost > 0){

				attackPower = ((ownerStats.Damage * ownerStats.Strength/2 + (ownerStats.Damage * ownerStats.Magic)) * Random.Range(1,4));
				damage = (attackPower - (targetStats.Armor * 0.75f));

				}else {

					attackPower = ((ownerStats.Damage * ownerStats.Strength) * Random.Range(1,4));
					damage = (attackPower - targetStats.Armor);
		}

			this.owner.GetComponent<Animator> ().Play (this.attackAnimation);

			targetStats.receiveDamage ((int) damage);

			ownerStats.CurrentMana -= (int) this.manaCost;

			
		}
	}
}
