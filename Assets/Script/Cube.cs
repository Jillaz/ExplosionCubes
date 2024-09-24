using UnityEngine;

[RequireComponent (typeof(Painter))]
[RequireComponent (typeof(Collider))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _splitChance;

    public Vector3 Scale => transform.localScale;
    public int SplitChance => _splitChance;

    public void Init(Vector3 scale, int splitChance)
    {
        transform.localScale = scale;
        _splitChance = splitChance;
        ChangeColor();
    }

    public bool CanSplit()
    {
        int minSplitChance = 0;
        int maxSplitChance = 100;
        int chance;

        chance = Random.Range(minSplitChance, maxSplitChance);       

        return chance <= _splitChance;
    }

    public Rigidbody GetRigidbody() 
    {
        Collider collider = GetComponent<Collider>();

        return collider.attachedRigidbody;
    }

    private void ChangeColor()
    {
        Painter painter = GetComponent<Painter>();
        painter.SetRandomColor();
    }
}

