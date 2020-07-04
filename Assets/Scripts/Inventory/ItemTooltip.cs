using UnityEngine;
using UnityEngine.UI;
using System.Text;


public class ItemTooltip : MonoBehaviour
{

public static ItemTooltip Instance;
[SerializeField] Text ItemNameText;
[SerializeField] Text ItemTypeText;
[SerializeField] Text ItemStatsText;
[SerializeField] Text ItemDescriptionText;
private StringBuilder sb = new StringBuilder();

private void Awake() {
    if(Instance == null){
        Instance = this;    
    } else {
        Destroy(this);        
    }
    gameObject.SetActive(false);
    
}

public void ShowTooltip(Item item)
{
    gameObject.SetActive(true);

    ItemNameText.text = item.itemName;
    ItemTypeText.text = item.GetItemType().ToString();
    ItemDescriptionText.text = item.itemDescription;

    sb.Length = 0;
    
    if(item is EquippableItem){
        EquippableItem equippableItem = (EquippableItem) item;
        AddStat(equippableItem.DamageBonus, "Damage");
        AddStat(equippableItem.ArmorBonus, "Armor");
        AddStat(equippableItem.StrengthBonus, "Strenght");
        AddStat(equippableItem.AgilityBonus, "Agility");
        AddStat(equippableItem.MagicBonus, "Magic");
        AddStat(equippableItem.HealthBonus, "Health");
        AddStat(equippableItem.ManaBonus, "Mana");
        AddStat(equippableItem.HealthPercentBonus * 100, "% Health");
        AddStat(equippableItem.ManaPercentBonus * 100, "% Mana");
        ItemStatsText.text = sb.ToString();

    }
    
    
}

    public void HideTooltip()
    {
     gameObject.SetActive(false);
    }

    private void AddStat(float bonus, string statName)
    {
        if (bonus != 0)
        {
            if(sb.Length > 0)
                sb.AppendLine();
            if(bonus > 0)
                sb.Append("+");

            sb.Append(bonus);
            sb.Append(statName);
        }
    }





}
