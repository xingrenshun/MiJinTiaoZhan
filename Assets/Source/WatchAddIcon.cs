using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchAddIcon : MonoBehaviour
{
    public void OnClickAddIcon()
    {
        GuangGao.Instance.ShowReward(() =>
        {
            GameManager.singleton.ChangeIcon(50);
        });
    }
}
