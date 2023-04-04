using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private List<Dice> _diceList;
    public static ResultManager Instance { get; private set; }

    public string _lastResult;

    public event EventHandler<OnResultChangedEventArgs> OnResultChanged;
    public class OnResultChangedEventArgs:EventArgs {
        public string LastResult;
    }

    public void Awake() {
        Instance = this;
    }

    private void Start() {
        foreach(Dice dice in _diceList) {
            dice.OnScoreCounted += Dice_OnScoreCounted;
        }
    }

    private void Dice_OnScoreCounted(object sender, EventArgs e) {
        Dice dice = (Dice)sender;
        Debug.Log($"ResultManager: {dice.Score}");
        bool hasScoreForEveryDice = true;

        foreach(Dice d in _diceList) {
            if(d.Score==0) {
                hasScoreForEveryDice = false; 
                break;
            }
        }
        if(hasScoreForEveryDice) {
            OnResultChanged?.Invoke(this, new OnResultChangedEventArgs {
                LastResult = GetResult()
            }); 
        }
    }

    public void AddDice(Dice dice) {
        _diceList.Add(dice);
        dice.OnScoreCounted += Dice_OnScoreCounted;
    }

    public void RemoveDice(Dice dice) {
        _diceList.Remove(dice);
        dice.OnScoreCounted -= Dice_OnScoreCounted;
    }

    private  string GetResult() {
        StringBuilder stringBuilder = new StringBuilder();
        bool isFirst = true;
        int result = 0;
        foreach (Dice dice in _diceList) {
            if (!isFirst) {
                stringBuilder.Append(" + ");
            } else {
                isFirst = false;
            }
            stringBuilder.Append(dice.Score);
            result += dice.Score;
        }
        stringBuilder.Append(" = ");
        stringBuilder.Append(result);
        return stringBuilder.ToString();
    }
}
