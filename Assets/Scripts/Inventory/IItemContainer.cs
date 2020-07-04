
public interface IItemContainer
{
	bool CanAddItem(Item item, int amount = 1);
	bool AddItem(Item item);
	bool RemoveItem(Item item);
	void Clear();

	
}