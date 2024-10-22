using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 10f;    // ī�޶� �̵� �ӵ�
    public float lookSpeed = 2f;     // ī�޶� ȸ�� �ӵ�
    public float zoomSpeed = 10f;    // ī�޶� �� �ӵ�
    public float panSpeed = 10f;     // ��� �̵� �ӵ�

    private float yaw = 0f;          // ���콺 �¿� ȸ��
    private float pitch = 0f;        // ���콺 ���� ȸ��

    void Update()
    {
        // ī�޶� �̵� (WASD Ű)
        float moveForward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveRight = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveUp = 0f;
        if (Input.GetKey(KeyCode.Q)) moveUp = moveSpeed * Time.deltaTime;    // ���� �̵� (Q)
        if (Input.GetKey(KeyCode.E)) moveUp = -moveSpeed * Time.deltaTime;   // �Ʒ��� �̵� (E)

        Vector3 move = transform.forward * moveForward + transform.right * moveRight + transform.up * moveUp;
        transform.position += move;

        // ���콺�� ī�޶� ȸ��
        if (Input.GetMouseButton(0)) // ������ ���콺 ��ư�� ������ �� ȸ��
        {
            yaw += lookSpeed * Input.GetAxis("Mouse X");
            pitch -= lookSpeed * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -90f, 90f);  // ���� ȸ�� ���� ����

            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }

        // ���콺 ��ũ�ѷ� �� ��/�� �ƿ�
        float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        transform.position += transform.forward * scroll;

        // ��� ���콺 ��ư���� ��� �̵�
        if (Input.GetMouseButton(2)) // ��� ���콺 ��ư�� ������ �� ��� �̵�
        {
            float panX = -Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            float panY = -Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;
            transform.Translate(new Vector3(panX, panY, 0), Space.Self);
        }
    }
}
