using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

sealed internal class UISignal : MonoBehaviour
{
    #region Values
    [Serializable]
    internal class Event
    {
        [SerializeField] internal SandboxEvent sandboxEvent;
        [SerializeField] internal UnityEvent unityEvent;
    }
    [SerializeField] private List<Event> _events;

    [Serializable]
    internal class Value
    {
        [SerializeField] internal SandboxValue sandboxValue;
        [SerializeField] internal string stringFormat;
        [SerializeField] internal TextMeshProUGUI text;
    }
    [SerializeField] private List<Value> _values;
    #endregion

    #region Unity Functions
    private void Awake()
    {
    }
    #endregion

    #region Functions
    internal void Invoke(SandboxEvent sandboxEvent)
    {
        Event aEvent = _events.Find(e => e.sandboxEvent == sandboxEvent);
        if (aEvent != null)
            aEvent.unityEvent.Invoke();
    }

    internal void Output(SandboxValue sandboxValue, string value)
    {
        for (int i = 0; i < _values.Count; i++)
        {
            Value aValue_ = _values[i];
            if (aValue_.sandboxValue == SandboxValue.CoinCount)
            {
                string valueString = aValue_.stringFormat == string.Empty ? value : String.Format(aValue_.stringFormat, value);
                aValue_.text.text = valueString;
            }
        }
        Value aValue = _values.Find(e => e.sandboxValue == sandboxValue);
        
        if (aValue != null)
        {
            if (aValue.text == null)
                return;
            string valueString = aValue.stringFormat == string.Empty ? value : String.Format(aValue.stringFormat, value);
            aValue.text.text = valueString;
        }

        
    }
    #endregion
}
