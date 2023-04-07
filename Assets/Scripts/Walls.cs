using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    [SerializeField] private List<Transform> _wallsList;
    [SerializeField] private float radius = 20f;
    


    public List<Transform> WallsList => _wallsList;

    public float Radius  => radius;



    private void OnDrawGizmos() {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
