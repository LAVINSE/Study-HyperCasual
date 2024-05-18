using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    #region ����
    public List<GameObject> paperList = new List<GameObject>();
    public List<GameObject> moneyList = new List<GameObject>();
    public Transform paperPoint;
    public GameObject paperPrefab;
    public GameObject moneyPrefab;
    public Transform moneyPoint;
    #endregion // ����

    #region �Լ�
    /** �ʱ�ȭ */
    private void Start()
    {
        StartCoroutine(GenerateMoney());
    }

    /** å�� ���̸� �����Ѵ� */
    public void GetPaper()
    {
        // ���� ����
        GameObject paper = Instantiate(paperPrefab);
        paper.transform.position = new Vector3(paperPoint.position.x, paperPoint.position.y + ((float)paperList.Count / 20),
            paperPoint.position.z);
        paperList.Add(paper);
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

    #region �ڷ�ƾ
    /** å�� �ִ� ���̸� ������ ��ȯ�Ѵ� */
    private IEnumerator GenerateMoney()
    {
        while (true)
        {
            if(paperList.Count > 0)
            {
                // �� ����
                GameObject paper = Instantiate(moneyPrefab);
                paper.transform.position = new Vector3(moneyPoint.position.x, ((float)moneyList.Count / 10), moneyPoint.position.z);
                moneyList.Add(paper);

                // ������ �ִ� ���� ����
                RemoveLast();
            }
            yield return new WaitForSeconds(1f);
        }   
    }
    #endregion // �ڷ�ƾ
}
