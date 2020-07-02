using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.CharacterStats;

    public enum EquipmentType
	{
		Head,
		Chest,
		Gloves,
		Boots,
		Weapon1,
		Weapon2,
		Accessory1,
		Accessory2,
	}

[CreateAssetMenu]
public class EquippableItem : Item
{    

    public int StrengthBonus;
	public int AgilityBonus;
	public int MagicBonus;
    public int HealthBonus;
    public int ManaBonus;
    public int DamageBonus;
    public int ArmorBonus;
    /*public float StrengthPercentBonus;
	public float AgilityPercentBonus;
	public float MagicPercentBonus;*/
    public float HealthPercentBonus;
    public float ManaPercentBonus;

    [Space]
    public EquipmentType EquipmentType;


    public void Equip(PlayerStats c)
    {

        //c.agility.BaseValue += AgilityBonus;
        //c.Agility += AgilityBonus;    

        if(StrengthBonus != 0)
            c.strength.AddModifier(new StatModifier(StrengthBonus, StatModType.Flat, this));        
        if(AgilityBonus != 0)
            c.agility.AddModifier(new StatModifier(AgilityBonus, StatModType.Flat, this));        
        if(MagicBonus != 0)
            c.magic.AddModifier(new StatModifier(MagicBonus, StatModType.Flat, this));        
        if(HealthBonus != 0)
            c.maxHealth.AddModifier(new StatModifier(HealthBonus, StatModType.Flat, this));        
        if(ManaBonus != 0)
            c.maxMana.AddModifier(new StatModifier(ManaBonus, StatModType.Flat, this));
        
        if(DamageBonus != 0)
            c.damage += DamageBonus;        
        if(ArmorBonus != 0)
            c.armor += ArmorBonus;
        


        if(HealthPercentBonus != 0)
            c.maxHealth.AddModifier(new StatModifier(HealthPercentBonus, StatModType.Flat, this));        
        if(ManaPercentBonus != 0)
            c.maxMana.AddModifier(new StatModifier(ManaPercentBonus, StatModType.Flat, this));
        

    }


    public void Unequip(PlayerStats c)
    {
        c.strength.RemoveAllModifiersFromSource(this);
        c.agility.RemoveAllModifiersFromSource(this);
        c.magic.RemoveAllModifiersFromSource(this);
        c.maxHealth.RemoveAllModifiersFromSource(this);
        c.maxMana.RemoveAllModifiersFromSource(this);

        c.damage = c.damage -this.DamageBonus;
        c.armor = c.armor - this.ArmorBonus;

    }
    
    



  
    
}
