using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    #region ����
    public static Action OnPaperCollect;
    public static Action OnPaperGive;
    public static Action OnMoneyCollect;
    public static Action OnBuyDesk;
    public static PrintManager printManager;
    public static WorkerManager workerManager;
    public static BuyArea buyArea;
   
    private bool isCollecting;
    private bool isGive;
    #endregion // ����

    #region �Լ�
    /** �ʱ�ȭ */
    private void Start()
    {
        StartCoroutine(CollectCO());
    }

    /** ������ (Ʈ����) */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            // �� ȹ��
            OnMoneyCollect();
            Destroy(other.gameObject);
        }
    }

    /** ������ (Ʈ����) */
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BuyArea"))
        {
            // ����ũ ����
            OnBuyDesk();
            buyArea = other.gameObject.GetComponent<BuyArea>();
        }
        if (other.gameObject.CompareTag("CollectArea"))
        {
            // ���� ȹ��
            isCollecting = true;
            printManager = other.gameObject.GetComponent<PrintManager>();
        }
        if (other.gameObject.CompareTag("WorkArea"))
        {
            // ���� ��ȯ�ҿ� �ø���
            isGive = true;
            workerManager = other.gameObject.GetComponent<WorkerManager>();
        }
    }

    /** �������� (Ʈ����) */
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
    #endregion // �Լ�

    #region �ڷ�ƾ
    /** ���� ȹ�� �� ��ȯ�ҿ� �ش� */
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
    #endregion // �ڷ�ƾ
}
