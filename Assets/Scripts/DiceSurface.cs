using System;
using TMPro;
using UnityEngine;

[Serializable]
public class DiceSurface : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private TextMeshPro _textField;

    public int Score {
        get { return _score; }
        private set { _score = value; }
    }


    public void ActivateSurface(Color color) {
        _textField.color = color;
    }

    public void DeactivateSurface(Color color) {
        _textField.color = color;
    }
}
