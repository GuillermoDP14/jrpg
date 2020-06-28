using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.CharacterStats;

public class LoadInfo 
{ 
 
    public static void LoadAllInfo()
    {

        GameInfo.PlayerName = PlayerPrefs.GetString("PLAYERNAME");
        GameInfo.PlayerLevel = PlayerPrefs.GetInt("PLAYERLEVEL");

        GameInfo.Strength = PlayerPrefs.GetFloat("STRENGTH");
        GameInfo.Magic = PlayerPrefs.GetFloat("MAGIC");
        GameInfo.Agility = PlayerPrefs.GetFloat("AGILITY");

        GameInfo.Armor = PlayerPrefs.GetInt("ARMOR");
        GameInfo.Damage   = PlayerPrefs.GetInt("DAMAGE");

        GameInfo.MaxHealth = PlayerPrefs.GetInt("MAXHEALTH");
        GameInfo.MaxMana   = PlayerPrefs.GetInt("MAXMANA");
        GameInfo.CurrentHealth = PlayerPrefs.GetInt("CURRENTHEALTH");
        GameInfo.CurrentMana   = PlayerPrefs.GetInt("CURRENTMANA");
        GameInfo.Experience = PlayerPrefs.GetInt("EXPERIENCE");
        GameInfo.SpendPoints = PlayerPrefs.GetInt("SPENDPOINTS");

        Debug.Log(GameInfo.Strength);
        Debug.Log("Info Loaded"); 
    }
  
}