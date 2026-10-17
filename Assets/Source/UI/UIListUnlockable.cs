using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

internal class UIListUnlockable : UIList
{
    public TextMeshProUGUI BuyText;
    [SerializeField] private GameObject _screenContainer;

    [SerializeField] private UIUnlocker _uIUnlockScreen;
    [SerializeField] private UnlockableType _unlockableType;
    public UnlockableType _UnlockableType
    {
        get {  return _unlockableType; }
    }

    [SerializeField] private UIListItemUnlockable _uIListItemUnlockablePrefab;
    [SerializeField] public UIBipedDesigner _uIBipedDesigner;
    
    protected override void Awake ()
    {
        base.Awake();
        foreach (Unlockable unlockable in GetUnlockables())
        {
            GameObject newGameObject = Instantiate(_uIListItemUnlockablePrefab.gameObject);
            UIListItemUnlockable newUIListItem = newGameObject.GetComponent<UIListItemUnlockable>();
            newUIListItem.Populate(unlockable, this, ClickCallback);
            Add(newUIListItem);
        }
    }

    private Unlockable[] GetUnlockables()
    {
        switch (_unlockableType)
        {
            case UnlockableType.Costume:
                return InvestmentManager.singleton.UnlockableCostumes;
            case UnlockableType.Effect:
                return InvestmentManager.singleton.UnlockableEffects;
        }
        return null;
    }

    private void ClickCallback(Unlockable unlockable, UIListItemUnlockable uIListItemUnlockable)
    {
        if (unlockable.Unlocked)
        {
            if (_unlockableType == UnlockableType.Costume)
                _uIBipedDesigner.SetCostume(unlockable);
            else if (_unlockableType == UnlockableType.Effect)
                _uIBipedDesigner.SetEffect(unlockable);
            Close();
        }
        else
        {
            _uIUnlockScreen.Show(unlockable, uIListItemUnlockable);
            if (_unlockableType == UnlockableType.Costume)
            {
                if (BuyText != null)
                    BuyText.text = "¹ºÂòÆ¤·ô";
            }             
            else if (_unlockableType == UnlockableType.Effect)
                    if (BuyText != null)
                        BuyText.text = "¹ºÂòÐ§¹û";
        }
    }

    internal void Close()
    {
        _screenContainer.SetActive(false);
    }
}
