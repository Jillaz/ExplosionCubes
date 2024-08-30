using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _splitChance;

    public Vector3 Scale => transform.localScale;
    public int SplitChance => _splitChance;

    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    public void SetSplitChance(int splitChance)
    {
        _splitChance = splitChance;
    }
}

