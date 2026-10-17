using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(RectTransform))]
internal class UIListItem : MonoBehaviour
{
    [SerializeField] protected int _value;
    [SerializeField] protected RawImage _rawImage;
    [SerializeField] protected TextMeshProUGUI _text;
    protected Action<int> _callback;
    
    internal void Populate(int value, Sprite sprite, string text, Action<int> callback)
    {
        _value = value;
        _rawImage.texture = sprite.texture;
        _text.text = text;
        _callback = callback;
    }

    public virtual void CallbackClick()
    {
        _callback.Invoke(_value);
    }
}
