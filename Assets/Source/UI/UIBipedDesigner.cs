using System.Collections;
using System.Collections.Generic;
using TMPro;
using TTSDK;
using UnityEngine;
using UnityEngine.UI;

internal sealed class UIBipedDesigner : MonoBehaviour
{
    public BipedDesign _bipedDesign;
    [SerializeField] TMP_InputField _inputField;
    [SerializeField] RawImage _costumeRawImage;
    [SerializeField] RawImage _effectRawImage;
    [SerializeField] UIList _uIList;
    private bool InputEmpty
    {
        get
        {
            if(_inputField.text != string.Empty)
            {
                foreach (char character in _inputField.text)
                    if (character != ' ')
                        return false;
                return true;
            }
            return true;
        }
    }

    private UIListItemBipedDesign _uIListItemBipedDesign;

    internal void Populate(BipedDesign bipedDesign, UIListItemBipedDesign uIListItemBipedDesign)
    {
        _bipedDesign = bipedDesign;
        _uIListItemBipedDesign = uIListItemBipedDesign;
        _inputField.text = _bipedDesign.Name;
        _costumeRawImage.texture = InvestmentManager.singleton.CostumeSprites[_bipedDesign.SpriteIndex].texture;
    }

    internal void SetCostume(Unlockable unlockable)
    {
        _costumeRawImage.texture = unlockable.Preview.texture;
        _bipedDesign.SpriteIndex = InvestmentManager.singleton.GetUnlockableIndex(unlockable, InvestmentManager.singleton.UnlockableCostumes);
    }
    internal void SetEffect(Unlockable unlockable)
    {
        _effectRawImage.texture = unlockable.Preview.texture;
        _bipedDesign.EffectIndex = InvestmentManager.singleton.GetUnlockableIndex(unlockable, InvestmentManager.singleton.UnlockableEffects);
    }

    public void Back()
    {
        if(!InputEmpty)
            _bipedDesign.Name = _inputField.text;
        _uIListItemBipedDesign.Refresh();
        this.gameObject.SetActive(false);
        _uIList.gameObject.SetActive(true);
        InvestmentManager.singleton.Save();
    }
    public void TestSensitive()
    {
        Debug.Log("检测是否为敏感词");
        TT.SensitiveWordCheck(_inputField.text,
        result =>
        {
            Debug.Log(" 是否是敏感词:" + result);
            if (result)
            {
                _inputField.text = "卡皮巴拉";
            }
        },
        errMsg =>
        {
            Debug.Log("检测失败，原因:" + errMsg);
        });
    }
}
 