using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [Header("Database")]
    [SerializeField] private ItemDatabase itemDatabase;

    [Header("Prefab")]
    [SerializeField] private ItemPrefab itemPrefab;

    [Header("Panel")]
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform content;

    private void Start()
    {
        ItemConfig[] _itemConfigs = itemDatabase.GetAllItems();

        foreach(ItemConfig _config in _itemConfigs)
        {
            Instantiate<ItemPrefab>(itemPrefab, content).SetItemConfiguration(_config);
        }
    }

    private void Update() 
    {
        if(canvasGroup.blocksRaycasts)
        {
            if(Input.GetMouseButtonDown(0))
            {
                canvasGroup.blocksRaycasts = false;
            }
        }
        else
        {
            if(Input.GetMouseButtonUp(0))
            {
                canvasGroup.blocksRaycasts = true;
            }
        }
    }
}