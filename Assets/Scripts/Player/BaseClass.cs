using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass 
{
    private float strength;
    private float magic;
    private float agility;
    private int damage;
    private int armor;
    private int health;
    private int mana;

    public float Strength
    {
        get{ return strength;}
        set{ strength = value;}
    }

    public float Magic
    {
        get{ return magic;}
        set{ magic = value;}
    }

    public float Agility
    {
        get{ return agility;}
        set{ agility = value;}
    }

    public int Armor
    {
        get{ return armor;}
        set{ armor = value;}
    }

     public int Damage
    {
        get{ return damage;}
        set{ damage = value;}
    }

    public int Health
    {
        get{ return health;}
        set{ health = value;}
    }

    public int Mana
    {
        get{ return mana;}
        set{ mana = value;}
    }

}