using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyArea : MonoBehaviour
{
    #region 변수
    public Image progressImage;
    public GameObject deskObject;
    public GameObject buyObject;
    public float cost;
    public float currentMoney;
    public float progress;
    #endregion // 변수

    #region 함수
    public void Buy(int goldAmount, ref int moneyCount)
    {
        // 현재 돈이 지불해야되는 돈이랑 같을 경우, 종료
        if(currentMoney == cost) { this.enabled = false; return; }

        // 지불한 값 만큼 돈 감소
        moneyCount -= goldAmount;

        currentMoney += goldAmount;
        progress = currentMoney / cost;
        progressImage.fillAmount = progress;

        // 가득 채워졌을 경우
        if(progress >= 1)
        {
            buyObject.SetActive(false);
            deskObject.SetActive(true);
        }
    }
    #endregion // 함수
}
