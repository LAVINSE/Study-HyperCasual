using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyArea : MonoBehaviour
{
    #region ����
    public Image progressImage;
    public GameObject deskObject;
    public GameObject buyObject;
    public float cost;
    public float currentMoney;
    public float progress;
    #endregion // ����

    #region �Լ�
    public void Buy(int goldAmount, ref int moneyCount)
    {
        // ���� ���� �����ؾߵǴ� ���̶� ���� ���, ����
        if(currentMoney == cost) { this.enabled = false; return; }

        // ������ �� ��ŭ �� ����
        moneyCount -= goldAmount;

        currentMoney += goldAmount;
        progress = currentMoney / cost;
        progressImage.fillAmount = progress;

        // ���� ä������ ���
        if(progress >= 1)
        {
            buyObject.SetActive(false);
            deskObject.SetActive(true);
        }
    }
    #endregion // �Լ�
}
