using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIList : MonoBehaviour
{
    public int mDataCount = 100;
    public UIInfiniteTable mInfiniteTable;

    private List<UIListItem> mListItem = new List<UIListItem>();
    // Use this for initialization
    void Start()
    {

        mInfiniteTable.onGetItemComponent = OnGetItemComponent;
        mInfiniteTable.onReposition = OnReposition;

        Refresh();
    }

    //获取列表 item身上的脚本
    private void OnGetItemComponent(GameObject obj)
    {
        mListItem.Add(obj.GetComponent<UIListItem>());
    }

    //刷新UI 回调 -- 用来更新数据
    private void OnReposition(GameObject go, int dataIndex, int childIndex)
    {
        mListItem[childIndex].Refresh(dataIndex);
    }

    private void Refresh()
    {
        //赋值数据总数
        mInfiniteTable.TableDataCount = mDataCount;
        //刷新UI
        mInfiniteTable.RefreshData();
    }
}
