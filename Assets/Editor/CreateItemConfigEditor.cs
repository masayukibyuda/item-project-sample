using UnityEngine;
using UnityEditor;

public class CreateItemConfigEditor : EditorWindow 
{
    private Sprite sprite;
    private string description;

    [MenuItem("UI-Tutorial/CreateItemConfigEditor")]
    private static void ShowWindow() 
    {
        var window = GetWindow<CreateItemConfigEditor>();
        window.titleContent = new GUIContent("Create Item Config");
        window.minSize = new Vector2(300, 700);
        window.maxSize = new Vector2(300, 700);
        window.Show();
    }

    private void OnGUI() 
    {
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Target Sprite: ");
            sprite = EditorGUILayout.ObjectField(sprite, typeof(Sprite), true) as Sprite;
        EditorGUILayout.EndHorizontal();

        if(sprite == null)
        {
            return;
        }

        EditorGUILayout.LabelField(string.Empty);

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            GUILayout.Box(sprite.texture, new GUILayoutOption[] { 
                GUILayout.MinWidth(128),
                GUILayout.MinHeight(128),
                GUILayout.MaxWidth(128),
                GUILayout.MaxHeight(128),
            });
            EditorGUILayout.Space();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField(string.Empty);

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            GUILayout.Box($"Item Key: {sprite.name}");
            EditorGUILayout.Space();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField(string.Empty);

        EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Description: ");
            GUILayout.Box($"Item Key: {sprite.name}");
            EditorGUILayout.Space();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField(string.Empty);

        EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            if(GUILayout.Button("Create Item Config")) {
                CreateItemConfig(sprite);
            }
            EditorGUILayout.Space();
        EditorGUILayout.EndHorizontal();
    }

    private void CreateItemConfig(Sprite p_sprite)
    {
        ItemConfig _itemConfig = ScriptableObject.CreateInstance<ItemConfig>();
        _itemConfig.SetUp(p_sprite.name, p_sprite, "");

        AssetDatabase.CreateAsset(_itemConfig, $"Assets/Config/Item/{_itemConfig.Key}.asset");

        ItemDatabase _itemDatabase = (ItemDatabase)AssetDatabase.LoadAssetAtPath("Assets/Config/ItemDatabase.asset", typeof(ItemDatabase));
        _itemDatabase.AddItemConfig(_itemConfig);

        AssetDatabase.Refresh();
    }
}