using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "UI-Tutorial/ItemDatabase", order = 0)]
public class ItemDatabase : ScriptableObject 
{
    [SerializeField] private List<ItemConfig> itemConfigs;

    public void AddItemConfig(ItemConfig p_itemConfig)
    {
        itemConfigs.Add(p_itemConfig);
    }

    public ItemConfig GetItemConfig(string p_key)
    {
        foreach(ItemConfig _item in itemConfigs)
        {
            if(_item.Key == p_key)
            {
                return _item;
            }
        }

        return null;
    }

    public ItemConfig[] GetAllItems()
    {
        return itemConfigs.ToArray();
    }
}