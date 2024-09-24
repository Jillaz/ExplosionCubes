using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosioner _explosioner;

    private int _cubeClickMouseButton = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_cubeClickMouseButton))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    if (cube.CanSplit() == true)
                    {
                        List<Rigidbody> cubes;
                        Vector3 parentCubePosition;

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

