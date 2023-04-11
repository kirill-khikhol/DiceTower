using System;
using TMPro;
using UnityEngine;

public class DiceSurface :DiceSurfaceBase {
    [SerializeField] private TextMeshPro _textField;

    public override void ActivateSurface(Color color) {
        _textField.color = color;
    }

    public override void DeactivateSurface(Color color) {
        _textField.color = color;
    }
}
