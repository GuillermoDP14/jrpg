using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    void Awake() 
    {
        int length = FindObjectsOfType<GameInfo>().Length;
        if(length != 1){
            Destroy(this.gameObject);
        }else{
            DontDestroyOnLoad(this.gameObject);
        }

    }

    public static string PlayerName { get; set;}
    public static int PlayerLevel { get; set;}
    public static BaseClass PlayerClass { get; set;}
    public static float Strength { get; set;}
    public static float Magic { get; set;}
    public static float Agility { get; set;}
    public static int Armor { get; set;}
    public static int Damage { get; set;}    
    public static float MaxHealth { get; set;}
    public static float MaxMana { get; set;}
    public static int CurrentHealth { get; set;}
    public static int CurrentMana { get; set;}
    public static int Experience { get; set;}
    public static int SpendPoints { get; set;}
    public static float PlayerPositionX { get; set;}
    public static float PlayerPositionY { get; set;}

}