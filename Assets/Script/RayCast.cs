using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosioner _explosioner;

    private int _primaryMouseButtonIndex = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_primaryMouseButtonIndex))
        {
            Ray ray;
            RaycastHit hit;
            Cube cube;
            List<Rigidbody> cubes;
            Vector3 parentCubePosition;

            ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.TryGetComponent(out cube))
                {
                    if (cube.CanSplit() == true)
                    {
                        parentCubePosition = cube.transform.position;
                        cubes = _spawner.Spawn(cube);
                        _explosioner.Explode(cubes, parentCubePosition);
                    }
                    else
                    {                        
                        _explosioner.Explode(cube);
                    }
                }
            }
        }
    }
}

