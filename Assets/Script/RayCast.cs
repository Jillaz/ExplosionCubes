using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private Spawner _spawner;

    private void Update()
    {
        RaycastHit hit;
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            Transform objectHit = hit.transform;

            if (Input.GetMouseButtonDown(0))
            {
                _spawner.Spawn(objectHit);
            }
        }
    }
}

