using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    #region ����
    public int moneyCount = 0;
    #endregion // ����

    #region �Լ�
    private void OnEnable()
    {
        TriggerManager.OnMoneyCollect += IncreaseMoney;
        TriggerManager.OnBuyDesk += BuyArea;
    }

    private void OnDisable()
    {
        TriggerManager.OnMoneyCollect -= IncreaseMoney;
        TriggerManager.OnBuyDesk -= BuyArea;
    }

    /** ������ �����Ѵ� */
    private void BuyArea()
    {
        if(TriggerManager.buyArea != null)
        {
            // ���� ������ ���
            if(moneyCount >= 1)
            {
                // ������ �����Ѵ�
                TriggerManager.buyArea.Buy(1, ref moneyCount);
            }
        }
    }

    /** ���� ������Ų�� */
    private void IncreaseMoney()
    {
        moneyCount += 50;
    }
    #endregion // �Լ�
}
