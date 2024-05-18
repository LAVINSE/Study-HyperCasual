using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    #region 변수
    public static Action OnPaperCollect;
    public static Action OnPaperGive;
    public static Action OnMoneyCollect;
    public static Action OnBuyDesk;
    public static PrintManager printManager;
    public static WorkerManager workerManager;
    public static BuyArea buyArea;
   
    private bool isCollecting;
    private bool isGive;
    #endregion // 변수

    #region 함수
    /** 초기화 */
    private void Start()
    {
        StartCoroutine(CollectCO());
    }

    /** 접촉중 (트리거) */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            // 돈 획득
            OnMoneyCollect();
            Destroy(other.gameObject);
        }
    }

    /** 접촉중 (트리거) */
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BuyArea"))
        {
            // 데스크 구매
            OnBuyDesk();
            buyArea = other.gameObject.GetComponent<BuyArea>();
        }
        if (other.gameObject.CompareTag("CollectArea"))
        {
            // 종이 획득
            isCollecting = true;
            printManager = other.gameObject.GetComponent<PrintManager>();
        }
        if (other.gameObject.CompareTag("WorkArea"))
        {
            // 종이 교환소에 올리기
            isGive = true;
            workerManager = other.gameObject.GetComponent<WorkerManager>();
        }
    }

    /** 접촉종료 (트리거) */
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false;
            printManager = null;
        }
        if (other.gameObject.CompareTag("WorkArea"))
        {
            isGive = false;
            workerManager = null;
        }
        if (other.gameObject.CompareTag("BuyArea"))
        {
            buyArea = null;
        }
    }
    #endregion // 함수

    #region 코루틴
    /** 종이 획득 및 교환소에 준다 */
    private IEnumerator CollectCO()
    {
        while (true)
        {
            if(isCollecting == true)
            {
                OnPaperCollect();
            }
            if(isGive == true)
            {
                OnPaperGive();
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
    #endregion // 코루틴
}
