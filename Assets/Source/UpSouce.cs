using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpSouce : MonoBehaviour
{
    public TextMeshProUGUI SouceObj;

    private void OnEnable()
    {
        Debug.Log("PlayerPrefs.GetInt(\"MaxSouce\"):" + PlayerPrefs.GetInt("MaxSouce"));
        Debug.Log("int.Parse(SouceObj.text):" + int.Parse(SouceObj.text));
        if(PlayerPrefs.GetInt("MaxSouce") < int.Parse(SouceObj.text))
        {
            GuangGao.Instance.UploadScore(SouceObj.text);
            PlayerPrefs.SetInt("MaxSouce", int.Parse(SouceObj.text));
        }     
        GuangGao.Instance.ShowXP();
    }
}
