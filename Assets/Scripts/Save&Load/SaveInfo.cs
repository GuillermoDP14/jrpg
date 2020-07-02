using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.CharacterStats;


public class SaveInfo 
{ 
 
 public static void SaveAllInfo()
{
    PlayerPrefs.SetString("PLAYERNAME", GameInfo.PlayerName);
    PlayerPrefs.SetInt("PLAYERLEVEL", GameInfo.PlayerLevel);
    

    PlayerPrefs.SetFloat("STRENGTH", GameInfo.Strength);
    PlayerPrefs.SetFloat("MAGIC", GameInfo.Magic);
    PlayerPrefs.SetFloat("AGILITY", GameInfo.Agility);

    PlayerPrefs.SetInt("ARMOR", GameInfo.Armor);
    PlayerPrefs.SetInt("DAMAGE", GameInfo.Damage);   

    PlayerPrefs.SetFloat("MAXHEALTH", GameInfo.MaxHealth);
    PlayerPrefs.SetFloat("MAXMANA", GameInfo.MaxMana);   
    PlayerPrefs.SetInt("CURRENTHEALTH", GameInfo.CurrentHealth);
    PlayerPrefs.SetInt("CURRENTMANA", GameInfo.CurrentMana);   

    PlayerPrefs.SetInt("EXPERIENCE", GameInfo.Experience);   
    PlayerPrefs.SetInt("SPENDPOINTS", GameInfo.SpendPoints);   

    PlayerPrefs.SetFloat("PLAYERPOSITIONX", GameInfo.PlayerPositionX);   
    PlayerPrefs.SetFloat("PLAYERPOSITIONY", GameInfo.PlayerPositionY);   
    
    Debug.Log(PlayerPrefs.GetFloat("PLAYERNAME"));
    Debug.Log("Info Saved"); 
}
  
}