using System.Collections.Generic;
using UnityEngine;

public class Explosioner : MonoBehaviour
{
    [SerializeField] float _explosionRadius;
    [SerializeField] float _explosionForce;
    [SerializeField] float _bornExplosionRadius;
    [SerializeField] float _bornExplosionForce;

    public void Explode(Cube cube)
    {
        List<Rigidbody> explodingObjects = GetExplodableCubes(cube);

        foreach (var item in explodingObjects)
        {
            item.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
        }

        Destroy(cube.gameObject);
    }

    public void Explode(List<Rigidbody> cubes, Vector3 explosionPosition)
    {
        foreach (var item in cubes)
        {
            item.AddExplosionForce(_bornExplosionForce, explosionPosition, _bornExplosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableCubes(Cube cube)
    {
        List<Rigidbody> cubes = new();
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, _explosionRadius);

        foreach (Collider item in hits)
        {
            if (item.attachedRigidbody != null)
            {
                cubes.Add(item.attachedRigidbody);
            }
        }

        return cubes;
    }
}
