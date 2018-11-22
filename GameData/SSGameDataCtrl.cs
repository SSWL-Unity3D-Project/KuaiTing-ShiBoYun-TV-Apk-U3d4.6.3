using UnityEngine;

public class SSGameDataCtrl : MonoBehaviour
{
    [System.Serializable]
    public class UIData
    {
        /// <summary>
        /// 游戏时长.
        /// </summary>
        public float m_pGameTime = 300.0f;
        /// <summary>
        /// 路径总长.
        /// </summary>
        public float Distance = 6400;
        /// <summary>
        /// 关卡最大分数.
        /// </summary>
        public int MaxScore = 16000;
    }
    public UIData m_UIData;

    [System.Serializable]
    public class PlayerData
    {
        /// <summary>
        /// 最大圈数.
        /// </summary>
        [Range(1, 10)]
        public int QuanShuMax = 1;
    }
    public PlayerData m_PlayerData;

    static SSGameDataCtrl _Instance = null;
    public static SSGameDataCtrl GetInstance()
    {
        return _Instance;
    }

    void Awake()
    {
        _Instance = this;
    }
}