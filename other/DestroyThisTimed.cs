using UnityEngine;
using System.Collections;

public class DestroyThisTimed : MonoBehaviour
{
	[Range(0f, 100f)] public float TimeRemove = 5f;
    /// <summary>
    /// 爆炸粒子预置.
    /// </summary>
    GameObject LiZiPrefab;
    /// <summary>
    /// 道具宝箱预置.
    /// </summary>
    GameObject BaoXiangPrefab;
    // Use this for initialization
    void Start()
	{
		//Debug.Log("DestroyThisTimed -> objName "+gameObject.name);
		//Destroy(gameObject, TimeRemove);
        Invoke("DelayDestroyThis", TimeRemove);
	}

    public void InitInfo(GameObject liZi, GameObject baoXiang, float timeVal)
    {
        LiZiPrefab = liZi;
        BaoXiangPrefab = baoXiang;
        TimeRemove = timeVal;
    }

    void DelayDestroyThis()
    {
        if (LiZiPrefab != null)
        {
            GameObject obj = (GameObject)Instantiate(LiZiPrefab, transform.position, transform.rotation);
            SSMissionCleanup.GetInstance().AddObj(obj);
        }

        if (BaoXiangPrefab != null)
        {
            GameObject obj = (GameObject)Instantiate(BaoXiangPrefab, transform.position, transform.rotation);
            SSMissionCleanup.GetInstance().AddObj(obj);
        }
        Destroy(gameObject);
    }
}
