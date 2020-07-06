using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kryz.CharacterStats;
using System;

public class CharacterStats : MonoBehaviour, IComparable
{

    public string characterName;
    public int characterLevel = 1;
    public CharacterStat strength;
    public CharacterStat magic;
    public CharacterStat agility;
    public CharacterStat maxHealth;
    public CharacterStat maxMana;
    public int damage;
    public int armor;
    public int currentHealth;
    public int currentMana;

    [SerializeField]
	public Animator animator;

	[SerializeField]
	public GameObject damageTextPrefab;
	[SerializeField]	
	public Vector2 damageTextPosition;

	public int nextActTurn;

	public bool dead = false;

    public void receiveDamage(int damage) {
		this.CurrentHealth -= damage;
		//animator.Play ("Hit");
		Debug.Log("Damage: " + damage);
		GameObject HUDCanvas = GameObject.Find ("HUDCanvas");
		GameObject damageText = Instantiate (this.damageTextPrefab, HUDCanvas.transform) as GameObject;
		damageText.GetComponent<Text> ().text = "" + damage;
		Debug.Log("Texto de daño 2: " + damageText.GetComponent<Text>().text);
		damageText.transform.localPosition = this.damageTextPosition;
		damageText.transform.localScale = new Vector2 (1.0f, 1.0f);

		if (this.CurrentHealth <= 0) {
			this.dead = true;
			this.gameObject.tag = "DeadUnit";
			Destroy (this.gameObject);
		}
	}

	public void calculateNextActTurn(int currentTurn) {
		this.nextActTurn = currentTurn + (int)Math.Ceiling(100.0f / this.Agility);
        Debug.Log("CEILING" + this.nextActTurn);
	}

	public int CompareTo(object otherStats) {
		return nextActTurn.CompareTo (((CharacterStats)otherStats).nextActTurn);
	}

	public bool isDead() {
		return this.dead;
	}

    public string CharacterName
    {
        get{ return characterName;}
        set{ characterName = value;}
    }

    public int CharacterLevel
    {
        get{ return characterLevel;}
        set{ characterLevel = value;}
    }


    public float Strength
    {   
        get{ return strength.Value;}
        set{ strength.BaseValue = value;}
    }

    public float Magic
    {
        get{ return magic.Value;}
        set{ magic.BaseValue = value;}
    }

    public float Agility
    {
        get{ return agility.Value;}
        set{ agility.BaseValue = value;}
    }

    public float MaxHealth
    {
        get{ return maxHealth.Value;}
        set{ maxHealth.BaseValue = value;}
    }

    public float MaxMana
    {
        get{ return maxMana.Value;}
        set{ maxMana.BaseValue = value;}
    }

    public int CurrentHealth
    {
        get{ return currentHealth;}
        set{ currentHealth = value;}
    }

    public int CurrentMana
    {
        get{ return currentMana;}
        set{ currentMana = value;}
    }

    public int Damage
    {
        get{ return damage;}
        set{ damage = value;}
    }

    public int Armor
    {
        get{ return armor;}
        set{ armor = value;}
    }
 
}