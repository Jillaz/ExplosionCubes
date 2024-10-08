using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private int _minNumberCubes = 2;
    [SerializeField] private int _maxNumberCubes = 6;

    private int _numberCubes;

    public List<Rigidbody> Spawn(Cube parentCube)
    {
        Cube newCube;
        List<Rigidbody> cubes = new List<Rigidbody>();
        int reductionFactor = 2;

        _numberCubes = Random.Range(_minNumberCubes, _maxNumberCubes+1);        

        for (int i = 0; i < _numberCubes; i++)
        {
            newCube = Instantiate(parentCube, parentCube.transform.position, Quaternion.Euler(GetDirection()));
            newCube.Init(parentCube.Scale / reductionFactor, parentCube.SplitChance / reductionFactor);            
            cubes.Add(newCube.GetRigidbody());
        }

        Destroy(parentCube.gameObject);

        return cubes;
    }

    private Vector3 GetDirection()
    {
        float rotationX;
        float rotationY;
        float rotationZ;
        float minRotationAngle = 0f;
        float maxRotationAngle = 360f;

        rotationX = Random.Range(minRotationAngle, maxRotationAngle);
        rotationY = Random.Range(minRotationAngle, maxRotationAngle);
        rotationZ = Random.Range(minRotationAngle, maxRotationAngle);

        return new Vector3(rotationX, rotationY, rotationZ);
    }
}
