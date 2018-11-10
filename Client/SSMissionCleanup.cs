using UnityEngine;
using System.Collections;

public class SSMissionCleanup : MonoBehaviour
{
    static SSMissionCleanup _Instance;
    public static SSMissionCleanup GetInstance()
    {
        if (_Instance == null)
        {
            GameObject obj = new GameObject();
            obj.name = "_MissionCleanup";
            _Instance = obj.AddComponent<SSMissionCleanup>();
        }
        return _Instance;
    }

    /// <summary>
    /// 添加对象.
    /// </summary>
    internal void AddObj(GameObject obj)
    {
        if (obj != null)
        {
            obj.transform.SetParent(transform);
        }
    }
}
