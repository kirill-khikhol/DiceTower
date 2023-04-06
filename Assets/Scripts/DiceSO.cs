using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DiceSO : ScriptableObject
{
    public Dice dicePrefab;
    public string lable;


    public void AddDice(Transform spawnPoint) {
        Instantiate(dicePrefab, spawnPoint);
    }

}
