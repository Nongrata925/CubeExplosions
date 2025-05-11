using UnityEngine;

public class SpawnerCubes : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Cube _cubePrefab;

    private int _minAmountCubes = 2;
    private int _maxAmountCubes = 6;
    private int _scaleDivider = 2;
    
    public void Spawn(Cube parent)
    { 
        int amountCubes = Random.Range(_minAmountCubes, _maxAmountCubes + 1);
        
        Cube[] cubes = new Cube[amountCubes];
        
        for (int i = 0; i < amountCubes; i++)
        {
            cubes[i] = Instantiate(_cubePrefab, parent.transform.position, Quaternion.identity);
            cubes[i].Renderer.material.color = _colorChanger.SetRandomColor();
            cubes[i].transform.localScale = parent.transform.localScale / _scaleDivider;
        }
        
        _exploder.Explode(cubes, parent);
        Destroy(parent.gameObject);
    }
}