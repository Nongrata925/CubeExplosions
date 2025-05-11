using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;
    
    public void Explode(Cube[] cubes, Cube parent)
    {
        foreach (Cube cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(_force, parent.transform.position, _radius);
            cube.ReduceSplitChance(parent.Generation);
        }
    }
}
