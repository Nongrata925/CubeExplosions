using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private SpawnerCubes _spawner;
    
    private Camera _camera;
    private Ray _ray;
    
    private int _mousebuttonIndex = 0;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(_mousebuttonIndex))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out hit))
            {
                if (hit.collider.TryGetComponent<Cube>(out Cube cube))
                {
                    if (cube.CanSplit())
                    {
                        cube.IncreaseGeneration();
                        _spawner.Spawn(cube);
                    }
                    else
                    {
                        Destroy(cube.gameObject);
                    }
                }
            }
        }
    }
}
