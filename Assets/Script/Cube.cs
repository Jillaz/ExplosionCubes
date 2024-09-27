using UnityEngine;

[RequireComponent(typeof(Painter))]
[RequireComponent(typeof(Collider))]
public class Cube : MonoBehaviour
{
    private Painter _painter;
    private Collider _collider;

    [field: SerializeField] public int SplitChance { get; private set; }
    public Vector3 Scale => transform.localScale;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _painter = GetComponent<Painter>();
    }

    public void Init(Vector3 scale, int splitChance)
    {
        transform.localScale = scale;
        SplitChance = splitChance;
        ChangeColor();
    }

    public bool CanSplit()
    {
        int minSplitChance = 0;
        int maxSplitChance = 100;
        int chance;

        chance = Random.Range(minSplitChance, maxSplitChance);

        return chance <= SplitChance;
    }

    public Rigidbody GetRigidbody()
    {
        return _collider.attachedRigidbody;
    }

    private void ChangeColor()
    {
        _painter.SetRandomColor();
    }
}

