using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDiceButton:MonoBehaviour {
    [SerializeField] private DiceSO _diceSO;

    private void Awake() {
        
    }

    //private void OnValidate() {
    //    gameObject.name= $"Add{_diceSO.name}Button";
    //}

    public void AddDiceToTray() {
        DiceManager resultManager = DiceManager.Instance;
        Transform transform = resultManager.TrayEntryPoint;
        Dice dice= Instantiate<Dice>(_diceSO.dicePrefab, transform.position,Quaternion.identity);
        resultManager.AddDice(dice);
       // _diceSO.AddDice(spawnPoint);
    }
}
