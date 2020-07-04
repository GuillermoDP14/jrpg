using UnityEngine;

public abstract class UsableItemEffect : ScriptableObject
{
	public abstract void ExecuteEffect(UsableItem parentItem, PlayerStats player);

	public abstract string GetDescription();
}
