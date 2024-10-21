using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class test02 : MonoBehaviour
{
    private Rigidbody rb;

    // �� �信 Gizmos�� �׸��� �Լ�
    void OnDrawGizmos()
    {
    rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // ���� �߽��� ������ ���� ǥ��
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(rb.worldCenterOfMass, 0.01f);
        }
    }
}
