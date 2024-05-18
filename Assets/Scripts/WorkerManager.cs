using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    #region 변수
    public List<GameObject> paperList = new List<GameObject>();
    public List<GameObject> moneyList = new List<GameObject>();
    public Transform paperPoint;
    public GameObject paperPrefab;
    public GameObject moneyPrefab;
    public Transform moneyPoint;
    #endregion // 변수

    #region 함수
    /** 초기화 */
    private void Start()
    {
        StartCoroutine(GenerateMoney());
    }

    /** 책상에 종이를 생성한다 */
    public void GetPaper()
    {
        // 종이 생성
        GameObject paper = Instantiate(paperPrefab);
        paper.transform.position = new Vector3(paperPoint.position.x, paperPoint.position.y + ((float)paperList.Count / 20),
            paperPoint.position.z);
        paperList.Add(paper);
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

    #region 코루틴
    /** 책상에 있는 종이를 돈으로 교환한다 */
    private IEnumerator GenerateMoney()
    {
        while (true)
        {
            if(paperList.Count > 0)
            {
                // 돈 생성
                GameObject paper = Instantiate(moneyPrefab);
                paper.transform.position = new Vector3(moneyPoint.position.x, ((float)moneyList.Count / 10), moneyPoint.position.z);
                moneyList.Add(paper);

                // 가지고 있는 종이 제거
                RemoveLast();
            }
            yield return new WaitForSeconds(1f);
        }   
    }
    #endregion // 코루틴
}
