using System.Collections.Generic;
using UnityEngine;

public class Explosioner : MonoBehaviour
{
    [SerializeField] float _explosionRadius;
    [SerializeField] float _explosionForce;

    public void Explode()
    {
        List<Rigidbody> explodingObjects = GetExplodableCubes();

        foreach (var item in explodingObjects)
        {
            item.AddExplosionForce(_explosionForce, transform.position, _explosionForce);
        }
    }

    private List<Rigidbody> GetExplodableCubes()
    {
        List<Rigidbody> cubes = new();
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

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
