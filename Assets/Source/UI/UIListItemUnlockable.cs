using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(RectTransform))]
sealed internal class UIListItemUnlockable : UIListItem
{
    public TextMeshProUGUI StateText;
    public GameObject Icon;
    public TextMeshProUGUI IconText;
    private const string LOCKED_TEXT = "Use Coins";
    [SerializeField] private Color _unlockedTextColor;
    [SerializeField] private Color _lockedTextColor;
    private Unlockable _unlockable;
    private Action<Unlockable, UIListItemUnlockable> _unlockableCallback;
    private UIListUnlockable _uIListUnlockable;

    internal void Populate(Unlockable unlockable, UIListUnlockable uIListUnlockable, Action<Unlockable, UIListItemUnlockable> callback)
    {
        _unlockable = unlockable;
        _uIListUnlockable = uIListUnlockable;
        _unlockableCallback = callback;
        Display();
    }
    private void Display()
    {
        _rawImage.texture = _unlockable.Preview.texture;
        _text.text = _unlockable.Unlocked ? _unlockable.Name : LOCKED_TEXT;
        _text.color = _unlockable.Unlocked ? _unlockedTextColor : _lockedTextColor;
        ChangeState();
    }
    private void OnEnable()
    {
        if( _unlockable != null)
        {
            ChangeState();
        }
        
    }
    public void ChangeState()
    {
        if (_unlockable.Unlocked)
        {
            Icon.SetActive(false);
            StateText.gameObject.SetActive(true);
            if (_uIListUnlockable._UnlockableType == UnlockableType.Costume)
            {
                if (_uIListUnlockable._uIBipedDesigner._bipedDesign.SpriteIndex == InvestmentManager.singleton.GetUnlockableIndex(_unlockable, InvestmentManager.singleton.UnlockableCostumes))
                {
                    StateText.text = "使用中";
                }
                else
                {
                    StateText.text = "已拥有";
                }

            }
            else if (_uIListUnlockable._UnlockableType == UnlockableType.Effect)
            {
                if (_uIListUnlockable._uIBipedDesigner._bipedDesign.SpriteIndex == InvestmentManager.singleton.GetUnlockableIndex(_unlockable, InvestmentManager.singleton.UnlockableEffects))
                {
                    StateText.text = "使用中";
                }
                else
                {
                    StateText.text = "已拥有";
                }
            }

        }
        else
        {
            Icon.SetActive(true);
            StateText.gameObject.SetActive(false);
            IconText.text = _unlockable.Price.ToString();
        }
    }
    internal void Refresh()
    {
        Display();
    }
    public override void CallbackClick()
    {
        _unlockableCallback.Invoke(_unlockable, this);
    }
}
