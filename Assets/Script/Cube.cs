using UnityEngine;

[RequireComponent (typeof(Painter))]
[RequireComponent (typeof(Pusher))]

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

    public bool CanSplit()
    {
        int minSplitChance = 0;
        int maxSplitChance = 100;
        int chance;

        chance = Random.Range(minSplitChance, maxSplitChance);       

        return chance <= _splitChance;
    }

    public void ChangeColor()
    {
        Painter painter = GetComponent<Painter>();
        painter.SetRandomColor();
    }

    public void Push()
    {
        Pusher pusher = GetComponent<Pusher>();

        pusher.Push();
    }
}

