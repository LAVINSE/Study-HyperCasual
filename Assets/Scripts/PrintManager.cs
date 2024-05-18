using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintManager : MonoBehaviour
{
    #region ����
    public List<GameObject> paperList = new List<GameObject>();
    public GameObject paperPrefab;
    public Transform exitPoint;

    private bool isWorking;
    private int stackCount = 10;
    private int posDistance = 3;
    #endregion // ����

    #region �Լ�
    private void Start()
    {
        StartCoroutine(PrintPaperCO());
    }

    /** ������ �ִ� ���� �ϴϾ� ���� */
    public void RemoveLast()
    {
        if(paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
    }
    #endregion // �Լ�

    #region �ڷ�ƾ
    /** ���̸� �����Ѵ� */
    private IEnumerator PrintPaperCO()
    {
        while (true)
        {
            float paperCount = paperList.Count;
            int rowCount = (int)paperCount / stackCount;

            if (isWorking == true)
            {
                GameObject paper = Instantiate(paperPrefab);
                // papaerCount / 20 >> ���� ���� 20�� �ӽ÷� ����
                // stackCount��ŭ �׿��� ��� x�� �̵�
                paper.transform.position = new Vector3(exitPoint.position.x + ((float)rowCount / posDistance),
                    (paperCount % stackCount) / 20, exitPoint.position.z);
                paperList.Add(paper);

                // ���̰� 30�� �̻� �� ���
                if (paperList.Count >= 30)
                {
                    // ���� ���� ����
                    isWorking = false;
                }
            }  
            else if(paperList.Count < 30)
            {
                // ���� ����
                isWorking = true;
            }

            yield return new WaitForSeconds(1f);
        }  
    }
    #endregion // �ڷ�ƾ
}
