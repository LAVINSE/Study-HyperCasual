using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    #region 변수
    public int moneyCount = 0;
    #endregion // 변수

    #region 함수
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

    /** 지역을 구매한다 */
    private void BuyArea()
    {
        if(TriggerManager.buyArea != null)
        {
            // 돈이 존재할 경우
            if(moneyCount >= 1)
            {
                // 지역을 구매한다
                TriggerManager.buyArea.Buy(1, ref moneyCount);
            }
        }
    }

    /** 돈을 증가시킨다 */
    private void IncreaseMoney()
    {
        moneyCount += 50;
    }
    #endregion // 함수
}
