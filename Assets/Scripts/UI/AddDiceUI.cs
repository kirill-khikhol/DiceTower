using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddDiceUI : MonoBehaviour
{
    [SerializeField] private List<DiceSO> _diceSOList;
    [SerializeField] private GameObject _buttonPrefab;

    public bool isFirstTime = true;

    private void OnValidate() {
        Button[] buttonArray = GetComponentsInChildren<Button>();
        Debug.Log(buttonArray.Length);
        foreach(Button button in buttonArray) {
            //Destroy(button.gameObject);
        }


        foreach (DiceSO diceSO in _diceSOList) {
            Debug.Log($"OnValidate() {diceSO.name}");
            //DiceSO diceSO1 = Instantiate<Button>(diceSO);
        }
        //if (isFirstTime) {
        //    isFirstTime= false;

        //    Debug.Log("OnValidate()");
        //}
    }


   
}
