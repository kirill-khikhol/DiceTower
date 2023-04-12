using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceSurfaceComplicated :DiceSurfaceBase {
    
    [SerializeField] private List<TextMeshPro> _textFieldList;

    public override void ActivateSurface(Color color) {
        foreach(TextMeshPro _textField in _textFieldList) {
        _textField.color = color;
        }
    }

    public override void DeactivateSurface(Color color) {
        foreach (TextMeshPro _textField in _textFieldList) {
            _textField.color = color;
        }
    }
}
