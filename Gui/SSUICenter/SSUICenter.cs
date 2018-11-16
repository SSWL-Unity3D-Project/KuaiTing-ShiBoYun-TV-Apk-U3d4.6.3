using UnityEngine;

public class SSUICenter : SSGameMono
{
    /// <summary>
    /// UI中心锚点.
    /// </summary>
    Transform m_UICenterTr;
	// Use this for initialization
	public void Init(Transform uiCenterTr)
    {
        m_UICenterTr = uiCenterTr;
	}
    
    /// <summary>
    /// 是否退出游戏窗口.
    /// </summary>
    internal SSExitGameUI m_ExitGameUI;
    /// <summary>
    /// 产生"是否退出游戏"窗口.
    /// </summary>
    internal void SpawnExitGameDlg()
    {
        if (m_ExitGameUI != null)
        {
            return;
        }

        GameObject gmDataPrefab = (GameObject)Resources.Load("Prefab/GUI/ExitGameUI/ExitGameUI");
        if (gmDataPrefab != null)
        {
            SSDebug.Log("SpawnExitGameDlg...");
            GameObject obj = (GameObject)Instantiate(gmDataPrefab, m_UICenterTr);
            m_ExitGameUI = obj.GetComponent<SSExitGameUI>();
            m_ExitGameUI.Init();
        }
        else
        {
            SSDebug.LogWarning("SpawnExitGameDlg -> gmDataPrefab was null");
        }
    }

    /// <summary>
    /// 删除"是否退出游戏"窗口.
    /// </summary>
    internal void RemoveExitGameDlg()
    {
        if (m_ExitGameUI != null)
        {
            m_ExitGameUI.RemoveSelf();
            m_ExitGameUI = null;
            Resources.UnloadUnusedAssets();
        }
    }
}
