using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed= 10f;    // ī�޶�E�̵� �ӵ�
    public float lookSpeed = 2f;     // ī�޶�Eȸ��E�ӵ�
    public float zoomSpeed = 10f;    // ī�޶�E�� �ӵ�
    public float panSpeed = 10f;     // ��E�̵� �ӵ�

    private float yaw = 0f;          // ����E� �¿�Eȸ��E
    private float pitch = 0f;        // ����E� ���� ȸ��E

    void Update()
    {
        // ī�޶�E�̵� (WASD Ű)
        float moveForward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveRight = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveUp = 0f;
        if (Input.GetKey(KeyCode.Q)) moveUp = moveSpeed * Time.deltaTime;    // ���� �̵� (Q)
        if (Input.GetKey(KeyCode.E)) moveUp = -moveSpeed * Time.deltaTime;   // �Ʒ��� �̵� (E)

        Vector3 move = transform.forward * moveForward + transform.right * moveRight + transform.up * moveUp;
        transform.position += move;

        // ����E��� ī�޶�Eȸ��E
        if (Input.GetMouseButton(0)) // ������ ����E� ��ư�� ������ �� ȸ��E
        {
            yaw += lookSpeed * Input.GetAxis("Mouse X");
            pitch -= lookSpeed * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -90f, 90f);  // ���� ȸ��E���� ����

            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }

        // ����E� ��ũ�ѷ� �� ��/�� �ƿ�E
        float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        transform.position += transform.forward * scroll;

        // ����ѥ ����E� ��ư���� ��E�̵�
        if (Input.GetMouseButton(2)) // ����ѥ ����E� ��ư�� ������ �� ��E�̵�
        {
            float panX = -Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            float panY = -Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;
            transform.Translate(new Vector3(panX, panY, 0), Space.Self);
        }
    }
}
