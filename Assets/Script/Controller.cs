using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public ArticulationBody arm1; // 조절할 관절


    void Update()
    {
        // 키 입력 처리
        if (Input.GetKey(KeyCode.Z)) // Z 키로 속도 증가
        {
            SetTargetVelocity(0.05f);
        }
        else if (Input.GetKey(KeyCode.X)) // X 키로 속도 감소
        {
            SetTargetVelocity(-0.05f);
        }
    }

    private void SetTargetVelocity(float velocity)
    {
        var drive = arm1.yDrive; // ArticulationBody의 xDrive 가져오기
        drive.targetVelocity = velocity; // 타겟 속도 설정
        arm1.xDrive = drive; // 업데이트
    }
}
