using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchEffect : MonoBehaviour
{
    public IEnumerator EffectPush(float time)
    {
        yield return new WaitForSeconds(time);
        //���߿� Ǯ������ ��ü�ұ�� ������
        Destroy(gameObject);
    }
}
