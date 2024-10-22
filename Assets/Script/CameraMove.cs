using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 10f;    // 카메라 이동 속도
    public float lookSpeed = 2f;     // 카메라 회전 속도
    public float zoomSpeed = 10f;    // 카메라 줌 속도
    public float panSpeed = 10f;     // 평면 이동 속도

    private float yaw = 0f;          // 마우스 좌우 회전
    private float pitch = 0f;        // 마우스 상하 회전

    void Update()
    {
        // 카메라 이동 (WASD 키)
        float moveForward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveRight = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveUp = 0f;
        if (Input.GetKey(KeyCode.Q)) moveUp = moveSpeed * Time.deltaTime;    // 위로 이동 (Q)
        if (Input.GetKey(KeyCode.E)) moveUp = -moveSpeed * Time.deltaTime;   // 아래로 이동 (E)

        Vector3 move = transform.forward * moveForward + transform.right * moveRight + transform.up * moveUp;
        transform.position += move;

        // 마우스로 카메라 회전
        if (Input.GetMouseButton(0)) // 오른쪽 마우스 버튼을 눌렀을 때 회전
        {
            yaw += lookSpeed * Input.GetAxis("Mouse X");
            pitch -= lookSpeed * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -90f, 90f);  // 상하 회전 각도 제한

            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }

        // 마우스 스크롤로 줌 인/줌 아웃
        float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        transform.position += transform.forward * scroll;

        // 가운데 마우스 버튼으로 평면 이동
        if (Input.GetMouseButton(2)) // 가운데 마우스 버튼을 눌렀을 때 평면 이동
        {
            float panX = -Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            float panY = -Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;
            transform.Translate(new Vector3(panX, panY, 0), Space.Self);
        }
    }
}
