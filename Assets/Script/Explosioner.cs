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
        Vector3 distance;
        float calculatedExplosionForce;
        float explosionForcePerUnitDistance;
        float explosionForceScaleFactor;
        float explosionForceFactor;

        explosionForcePerUnitDistance = _explosionForce / _explosionRadius;
        explosionForceScaleFactor = _explosionForce / cube.Scale.x;
        explosionForceFactor = explosionForcePerUnitDistance * explosionForceScaleFactor;

        foreach (var item in explodingObjects)
        {
            distance = item.transform.position - cube.transform.position;

            if (distance.magnitude >= _explosionRadius)
            {
                continue;
            }

            calculatedExplosionForce = explosionForceFactor * (_explosionRadius - distance.magnitude);
            item.AddExplosionForce(calculatedExplosionForce, cube.transform.position, _explosionRadius);
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
