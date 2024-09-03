using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosioner _explosioner;

    private void Update()
    {
        Ray _ray;
        RaycastHit hit;
        Cube cube;
        int _primaryMouseButtonIndex = 0;

        if (Input.GetMouseButtonDown(_primaryMouseButtonIndex))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.TryGetComponent(out cube))
                {
                    if (cube.IsCanSplit() == true)
                    {
                        _spawner.Spawn(cube);
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

