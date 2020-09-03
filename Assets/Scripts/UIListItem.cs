using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIListItem : MonoBehaviour
{

    public Text mId;

    //更新数据
    public void Refresh(int index)
    {
        mId.text = (index + 1).ToString();
    }
}
