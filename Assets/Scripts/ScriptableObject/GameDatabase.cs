using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "GameDatabase", menuName = "GameDatabase")]
public class GameDatabase : SOSingleton<GameDatabase>
{
    [field: SerializeField] public GameObject BGCell { get; private set; }
    [field: SerializeField] public GameObject[] NormalItems { get; private set; }
    [field: SerializeField] public GameObject[] BonusItems { get; private set; }

    [field: SerializeField] public Sprite[] OriginalSkins { get; private set; }
    [field: SerializeField] public Sprite[] NewSkins { get; private set; }

    internal GameObject GetNormalItem(int index)
    {
        return NormalItems[index];
    }

    internal GameObject GetBonusItem(int index)
    {
        return BonusItems[index];
    }

    public void SetOriginalSkin()
    {
        SetSkin(OriginalSkins);
    }

    public void SetNewSkin()
    {
        SetSkin(NewSkins);
    }

    private void SetSkin(Sprite[] skins)
    {
        for (int i = 0; i < NormalItems.Length; i++)
        {
            if (NormalItems[i].TryGetComponent<SpriteRenderer>(out var spriteRenderer))
            {
                spriteRenderer.sprite = skins[i];
            }
        }

#if UNITY_EDITOR
        foreach (GameObject item in NormalItems)
        {
            PrefabUtility.SavePrefabAsset(item);
        }
        EditorUtility.DisplayDialog("Reskin Item", "Skin Set!", "OK");
#endif
    }
}
