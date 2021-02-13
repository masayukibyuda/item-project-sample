using UnityEngine;
using UnityEngine.UI;

public class ItemPrefab : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text description;

    private ItemConfig itemConfig;

    public void SetItemConfiguration(ItemConfig p_itemConfig)
    {
        itemConfig = p_itemConfig;

        icon.sprite = itemConfig.Sprite;
        description.text = itemConfig.Description;
    }

    public void OnHoverEnter()
    {
        description.enabled = true;
    }

    public void OnHoverExit()
    {
        description.enabled = false;
    }
}
