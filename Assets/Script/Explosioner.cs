using System.Collections.Generic;
using UnityEngine;

public class Explosioner : MonoBehaviour
{
    [SerializeField] float _explosionRadius;
    [SerializeField] float _explosionForce;

    public void Explode(Cube cube)
    {
        List<Rigidbody> explodingObjects = GetExplodableCubes(cube);

        foreach (var item in explodingObjects)
        {
            item.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
        }

        Destroy(cube.gameObject);
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
