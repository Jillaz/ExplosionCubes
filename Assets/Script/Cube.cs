using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _splitChance;

    public Vector3 Scale => transform.localScale;
    public int SplitChance => _splitChance;

    public void Init(Vector3 scale, int splitChance)
    {
        transform.localScale = scale;
        _splitChance = splitChance;        
    }

    public bool IsCanSplit()
    {
        int minSplitChance = 0;
        int maxSplitChance = 101;
        int chance;

        chance = Random.Range(minSplitChance, maxSplitChance);       

        return chance <= _splitChance;
    }
}

