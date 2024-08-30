using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private int _minNumberCubes = 2;
    [SerializeField] private int _maxNumberCubes = 4;

    private int _numberCubes;

    public void Spawn(Transform parentCube)
    {
        Cube newCube;
        Cube parentCubeParams;
        Cube cubeParams;
        Explosioner explosioner;
        Painter painter;
        int reductionFactor = 2;

        _numberCubes = Random.Range(_minNumberCubes, _maxNumberCubes);

        parentCubeParams = parentCube.GetComponent<Cube>();

        if (isCanSplit(parentCubeParams.SplitChance))
        {
            for (int i = 0; i < _numberCubes; i++)
            {
                newCube = Instantiate(_cube, parentCube.position, Quaternion.identity);
                cubeParams = newCube.GetComponent<Cube>();
                cubeParams.SetScale(parentCubeParams.Scale / reductionFactor);
                cubeParams.SetSplitChance(parentCubeParams.SplitChance / reductionFactor);

                painter = newCube.GetComponent<Painter>();
                painter.SetRandomColor();
            }
        }
        else
        {
            explosioner = parentCube.GetComponent<Explosioner>();
            explosioner.Explode();
        }

        Destroy(parentCube.gameObject);
    }

    public bool isCanSplit(int currentSplitChance)
    {
        int minSplitChance = 0;
        int maxSplitChance = 101;
        int splitChance;

        splitChance = Random.Range(minSplitChance, maxSplitChance);

        if (splitChance <= currentSplitChance)
        {
            return true;
        }

        return false;
    }
}
