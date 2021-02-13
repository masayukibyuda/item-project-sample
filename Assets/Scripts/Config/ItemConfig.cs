using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "UI-Tutorial/ItemConfig", order = 0)]
public class ItemConfig : ScriptableObject 
{   
    [SerializeField] private string key;
    [SerializeField] private Sprite sprite;
    [SerializeField] private string description;

    public string Key => key;
    public Sprite Sprite => sprite;
    public string Description => description;

    public void SetUp(string p_key, Sprite p_sprite, string p_description)
    {
        key = p_key;
        sprite = p_sprite;
        description = p_description;
    }
}