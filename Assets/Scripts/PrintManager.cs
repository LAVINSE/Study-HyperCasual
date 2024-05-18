using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintManager : MonoBehaviour
{
    #region 변수
    public List<GameObject> paperList = new List<GameObject>();
    public GameObject paperPrefab;
    public Transform exitPoint;

    private bool isWorking;
    private int stackCount = 10;
    private int posDistance = 3;
    #endregion // 변수

    #region 함수
    private void Start()
    {
        StartCoroutine(PrintPaperCO());
    }

    /** 가지고 있는 종이 하니씩 제거 */
    public void RemoveLast()
    {
        if(paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
    }
    #endregion // 함수

    #region 코루틴
    /** 종이를 생성한다 */
    private IEnumerator PrintPaperCO()
    {
        while (true)
        {
            float paperCount = paperList.Count;
            int rowCount = (int)paperCount / stackCount;

            if (isWorking == true)
            {
                GameObject paper = Instantiate(paperPrefab);
                // papaerCount / 20 >> 간격 설정 20은 임시로 설정
                // stackCount만큼 쌓였을 경우 x축 이동
                paper.transform.position = new Vector3(exitPoint.position.x + ((float)rowCount / posDistance),
                    (paperCount % stackCount) / 20, exitPoint.position.z);
                paperList.Add(paper);

                // 종이가 30장 이상 일 경우
                if (paperList.Count >= 30)
                {
                    // 종이 생성 종료
                    isWorking = false;
                }
            }  
            else if(paperList.Count < 30)
            {
                // 종이 생성
                isWorking = true;
            }

            yield return new WaitForSeconds(1f);
        }  
    }
    #endregion // 코루틴
}
