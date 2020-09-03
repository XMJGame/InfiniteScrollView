using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 资源类型
/// </summary>
public enum ResourceType
{
    UI,             //UI
}
/// <summary>
/// 资源管理
/// </summary>
public class ResourcesManager : MonoSingleton<ResourcesManager>
{

    #region Resources目录下 资源加载
    /// <summary>
    /// 存储从本地加载的资源
    /// </summary>
    private Dictionary<string, Object> m_ResourceList = new Dictionary<string, Object>();

    /// <summary>
    /// 根据资源类型 和 名字 从本地加载资源
    /// </summary>
    public T ResourcesLoadByTypeAndName<T>(ResourceType type, string name, bool isCache = true) where T : Object
    {
        string path = GetResourcePathByType(type) + name;
        return ResourcesLoad<T>(path, isCache);
    }

    /// <summary>
    /// 从本地加载资源
    /// </summary>
    public T ResourcesLoad<T>(string path, bool isCache = true) where T : Object
    {
        Object resource = null;
        if (!m_ResourceList.TryGetValue(path, out resource))
        {
            resource = Resources.Load(path,typeof(T));
            if (isCache) m_ResourceList.Add(path, resource);
            if (resource == null)
                Debug.LogError("ResourcesLoad错误，找不到对应资源：" + path);
        }
        return resource as T;
    }
    #endregion

    #region 通用
    /// <summary>
    /// 根据资源类型获取对应路径
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public string GetResourcePathByType(ResourceType type)
    {
        string path = "";
        switch (type)
        {
            case ResourceType.UI:
                {
                    path = "Prefabs/UI/";
                }
                break;
        }
        return path;
    }
    #endregion


    #region 通用
    /// <summary>
    /// 卸载所有缓存
    /// </summary>
    public void UnLoadAllCache()
    {
        m_ResourceList.Clear();
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }
    #endregion
}
