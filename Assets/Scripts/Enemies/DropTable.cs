using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/DropTable")]
public class DropTable : ScriptableObject
{
    public List<DropWithChance> drops;
}

[Serializable]
public struct DropWithChance
{
    public Drop drop;
    public float min;
    public float max;
    public bool integerDrop;
    [Range(0f, 1f)]
    public float chance;

    public float GetDropQuantity()
    {
        float rnd = UnityEngine.Random.Range(0f, 1f);
        if (rnd <= chance)
        {
            if (integerDrop)
            {
                return UnityEngine.Random.Range((int)min, (int)(max + 1f));
            }
            return UnityEngine.Random.Range(min, max);
        }
        return 0f;
    }
}

public struct DropWithAmount
{
    public Drop drop;
    public float amount;

    public DropWithAmount(Drop drop, float amount)
    {
        this.drop = drop;
        this.amount = amount;
    }
}
