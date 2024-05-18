using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    #region ����
    public List<GameObject> paperList = new List<GameObject>();
    public GameObject paperPrefab;
    public Transform collectPoint; // �÷��̰� ���� ��� ���� ��ġ

    private int paperLimit = 10; // �ִ� ��������
    #endregion // ����

    #region �Լ�
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
        // ���� ������ �ִ� ���� ������ �ִ� �������� �������
        if(paperList.Count < paperLimit)
        {
            // ���� ����
            GameObject paper = Instantiate(paperPrefab, collectPoint);
            paper.transform.position = new Vector3(collectPoint.position.x,
                collectPoint.position.y + ((float)paperList.Count / 20), collectPoint.position.z);
            paperList.Add(paper);

            if(TriggerManager.printManager != null)
            {
                // �ٴڿ� �ִ� ���� ����
                TriggerManager.printManager.RemoveLast();
            }
        }
    }

    /** ���̸� ��ȯ�ҿ� �ø��� */
    public void GivePaper()
    {
        // ���̸� ������ ���� ���
        if(paperList.Count > 0)
        {
            // ��ȯ�ҿ� ���̸� �ø���
            TriggerManager.workerManager.GetPaper();
            // ������ �ִ� ���� �ϳ��� ����
            RemoveLast();
        }
    }

    /** ������ �ִ� ���� �ϴϾ� ���� */
    public void RemoveLast()
    {
        if (paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
    }
    #endregion // �Լ�
}
