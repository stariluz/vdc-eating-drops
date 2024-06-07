using System;
using UnityEngine;

[Serializable]
public class RangeField
{
    [SerializeField]
    int m_lowerBound = 0;

    [SerializeField]
    int m_upperBound = 0;

    public int lowerBound
    {
        get => m_lowerBound;
    }

    public int upperBound
    {
        get => m_upperBound;
        set => m_upperBound = Math.Max(m_lowerBound, m_upperBound);
    }
}
