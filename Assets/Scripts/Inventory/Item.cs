using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


[CreateAssetMenu(menuName = "Items/Item")]
public class Item : ScriptableObject
{    

    [SerializeField] string id;
    public string ID { get { return id;}}
    public string itemName;
    public string itemDescription;
    public Sprite Icon;
    [Range(1,99)]
    public int MaximumStacks = 1;
    protected static readonly StringBuilder sb = new StringBuilder();

    #if UNITY_EDITOR
    private void OnValidate()    
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }
    #endif

    public virtual Item GetCopy()
    {
        return this;
    }

    public virtual void Destroy()
    {
                
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
