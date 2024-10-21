using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class test02 : MonoBehaviour
{
    private Rigidbody rb;

    // 씬 뷰에 Gizmos를 그리는 함수
    void OnDrawGizmos()
    {
    rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // 질량 중심을 빨간색 구로 표시
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(rb.worldCenterOfMass, 0.01f);
        }
    }
}
