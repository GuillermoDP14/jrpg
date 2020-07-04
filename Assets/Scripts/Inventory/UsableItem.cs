using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Usable Item")]
public class UsableItem : Item
{
	public bool IsConsumable;

	public List<UsableItemEffect> Effects;
    
    private StringBuilder sb = new StringBuilder();

	public virtual void Use(PlayerStats player)
	{
		foreach (UsableItemEffect effect in Effects)
		{
			effect.ExecuteEffect(this, player);
		}
	}

	public override string GetItemType()
	{
		return IsConsumable ? "Consumable" : "Usable";
	}

	public override string GetDescription()
	{
		sb.Length = 0;
		foreach (UsableItemEffect effect in Effects)
		{
			sb.AppendLine(effect.GetDescription());
		}
		return sb.ToString();
	}
}
