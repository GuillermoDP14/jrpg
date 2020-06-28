using UnityEngine;
using System;
using System.Collections;

public class PlayerStats : CharacterStats, IComparable {

    public BaseClass playerClass;

    public int experience;

	public int spendPoints;


	void Start() {
		
	}


	public void receiveExperience(int experience) {
		this.experience += experience;
	}

    public BaseClass PlayerClass
    {
        get{ return playerClass;}
        set{ playerClass = value;}
    }

    public int Experience
    {
        get{ return experience;}
        set{ experience = value;}
    }

	public int SpendPoints
    {
        get{ return spendPoints;}
        set{ spendPoints = value;}
    }

	


}
