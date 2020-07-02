using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

    public enum ItemtType
	{
        Gear,
        Usable,
        Quest,
	}

[CreateAssetMenu]
public class Item : ScriptableObject
{    

    [SerializeField] string id;
    public string ID { get { return id;}}
    public string itemName;
    public string itemDescription;
    public ItemtType itemtType;
    public Sprite Icon;
    [Range(1,99)]
    public int MaximumStacks = 1;


    private void OnValidate()    
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }

    public virtual Item GetCopy()
    {
        return this;
    }

    public virtual string GetItemType()
    {
        return "";
    }

    public virtual string GetDescription()
    {
        return "";
    }



}
