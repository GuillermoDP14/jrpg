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

        GameInfo.MaxHealth = PlayerPrefs.GetFloat("MAXHEALTH");
        GameInfo.MaxMana   = PlayerPrefs.GetFloat("MAXMANA");
        GameInfo.CurrentHealth = PlayerPrefs.GetInt("CURRENTHEALTH");
        GameInfo.CurrentMana   = PlayerPrefs.GetInt("CURRENTMANA");
        GameInfo.Experience = PlayerPrefs.GetInt("EXPERIENCE");
        GameInfo.SpendPoints = PlayerPrefs.GetInt("SPENDPOINTS");

        Debug.Log(GameInfo.PlayerName);
        Debug.Log("Info Loaded"); 
    }
  
}