using System;
using System.Linq;
using System.Collections.Generic;
using URandom = UnityEngine.Random;

public class Utils
{
    public static NormalItem.eNormalType GetRandomNormalType()
    {
        Array values = Enum.GetValues(typeof(NormalItem.eNormalType));
        NormalItem.eNormalType result = (NormalItem.eNormalType)values.GetValue(URandom.Range(0, values.Length));

        return result;
    }

    public static NormalItem.eNormalType GetRandomNormalTypeExcept(NormalItem.eNormalType[] types)
    {
        List<NormalItem.eNormalType> list = Enum.GetValues(typeof(NormalItem.eNormalType)).Cast<NormalItem.eNormalType>().Except(types).ToList();

        int rnd = URandom.Range(0, list.Count);
        NormalItem.eNormalType result = list[rnd];

        return result;
    }

    public static NormalItem.eNormalType GetTypeByAmountInBoard(List<NormalItem.eNormalType> types, Cell[,] cells, int boardSizeX, int boardSizeY) // return the type that has the least amount in the board
    {
        Dictionary<NormalItem.eNormalType, int> dict = new Dictionary<NormalItem.eNormalType, int>();

        for (int i = 0; i < types.Count; i++)
        {
            dict.Add(types[i], 0);
        }

        for (int x = 0; x < boardSizeX; x++)
        {
            for (int y = 0; y < boardSizeY; y++)
            {
                if (cells[x, y].Item is NormalItem item && dict.ContainsKey(item.ItemType))
                {
                    dict[item.ItemType]++;
                }
            }
        }

        NormalItem.eNormalType result = dict.OrderBy(x => x.Value).First().Key;

        return result;
    }
}
