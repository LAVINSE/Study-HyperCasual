using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    #region 변수
    public List<GameObject> paperList = new List<GameObject>();
    public GameObject paperPrefab;
    public Transform collectPoint; // 플레이가 종이 들고 있을 위치

    private int paperLimit = 10; // 최대 소지개수
    #endregion // 변수

    #region 함수
    private void OnEnable()
    {
        TriggerManager.OnPaperCollect += GetPaper;
        TriggerManager.OnPaperGive += GivePaper;
    }

    private void OnDisable()
    {
        TriggerManager.OnPaperCollect -= GetPaper;
        TriggerManager.OnPaperGive -= GivePaper;
    }

    private void GetPaper()
    {
        // 현재 가지고 있는 종이 개수가 최대 개수보다 작을경우
        if(paperList.Count < paperLimit)
        {
            // 종이 생성
            GameObject paper = Instantiate(paperPrefab, collectPoint);
            paper.transform.position = new Vector3(collectPoint.position.x,
                collectPoint.position.y + ((float)paperList.Count / 20), collectPoint.position.z);
            paperList.Add(paper);

            if(TriggerManager.printManager != null)
            {
                // 바닥에 있는 종이 제거
                TriggerManager.printManager.RemoveLast();
            }
        }
    }

    /** 종이를 교환소에 올린다 */
    public void GivePaper()
    {
        // 종이를 가지고 있을 경우
        if(paperList.Count > 0)
        {
            // 교환소에 종이를 올린다
            TriggerManager.workerManager.GetPaper();
            // 가지고 있는 종이 하나씩 제거
            RemoveLast();
        }
    }

    /** 가지고 있는 종이 하니씩 제거 */
    public void RemoveLast()
    {
        if (paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
    }
    #endregion // 함수
}
