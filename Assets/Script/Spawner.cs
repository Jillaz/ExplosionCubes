using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private int _minNumberCubes = 2;
    [SerializeField] private int _maxNumberCubes = 4;

    private int _numberCubes;

    public void Spawn(Cube parentCube)
    {
        Cube newCube;
        Painter painter;
        int reductionFactor = 2;

        _numberCubes = Random.Range(_minNumberCubes, _maxNumberCubes);        

        for (int i = 0; i < _numberCubes; i++)
        {
            newCube = Instantiate(_cube, parentCube.transform.position, Quaternion.identity);
            newCube.Init(parentCube.Scale / reductionFactor, parentCube.SplitChance / reductionFactor);
            
            painter = newCube.GetComponent<Painter>();
            painter.SetRandomColor();
        }

        Destroy(parentCube.gameObject);
    }
}
