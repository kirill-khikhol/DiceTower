using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public static ResultManager Instance { get; private set; }

    public string _lastResult;

    public event EventHandler<OnResultChangedEventArgs> OnResultChanged;
    public class OnResultChangedEventArgs:EventArgs {
        public string LastResult { get; private set; }
    }

    public void Awake() {
        Instance = this;
    }

    
}
