using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DiceSurfaceBase : MonoBehaviour
{
    [SerializeField] protected int _score;

    public int Score => _score;

    public abstract void ActivateSurface(Color color);

    public abstract void DeactivateSurface(Color color);
}
