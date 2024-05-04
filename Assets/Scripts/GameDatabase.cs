using UnityEngine;

[CreateAssetMenu(fileName = "GameDatabase", menuName = "GameDatabase")]
public class GameDatabase : SOSingleton<GameDatabase>
{
    [field: SerializeField] public GameObject BGCell { get; private set; }
    [field: SerializeField] public GameObject[] NormalItems { get; private set; }
    [field: SerializeField] public GameObject[] BonusItems { get; private set; }

    internal GameObject GetNormalItem(int index)
    {
        return NormalItems[index];
    }

    internal GameObject GetBonusItem(int index)
    {
        return BonusItems[index];
    }
}
