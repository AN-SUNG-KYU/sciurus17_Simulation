using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed= 10f;    // ﾄｫｸﾞｶ・ﾀﾌｵｿ ｼﾓｵｵ
    public float lookSpeed = 2f;     // ﾄｫｸﾞｶ・ﾈｸﾀ・ｼﾓｵｵ
    public float zoomSpeed = 10f;    // ﾄｫｸﾞｶ・ﾁﾜ ｼﾓｵｵ
    public float panSpeed = 10f;     // ﾆ・ﾀﾌｵｿ ｼﾓｵｵ

    private float yaw = 0f;          // ｸｶｿ・ｺ ﾁﾂｿ・ﾈｸﾀ・
    private float pitch = 0f;        // ｸｶｿ・ｺ ｻﾏ ﾈｸﾀ・

    void Update()
    {
        // ﾄｫｸﾞｶ・ﾀﾌｵｿ (WASD ﾅｰ)
        float moveForward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveRight = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveUp = 0f;
        if (Input.GetKey(KeyCode.Q)) moveUp = moveSpeed * Time.deltaTime;    // ﾀｧｷﾎ ﾀﾌｵｿ (Q)
        if (Input.GetKey(KeyCode.E)) moveUp = -moveSpeed * Time.deltaTime;   // ｾﾆｷ｡ｷﾎ ﾀﾌｵｿ (E)

        Vector3 move = transform.forward * moveForward + transform.right * moveRight + transform.up * moveUp;
        transform.position += move;

        // ｸｶｿ・ｺｷﾎ ﾄｫｸﾞｶ・ﾈｸﾀ・
        if (Input.GetMouseButton(0)) // ｿﾀｸ･ﾂﾊ ｸｶｿ・ｺ ｹｰﾀｻ ｴｭｷｶﾀｻ ｶｧ ﾈｸﾀ・
        {
            yaw += lookSpeed * Input.GetAxis("Mouse X");
            pitch -= lookSpeed * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -90f, 90f);  // ｻﾏ ﾈｸﾀ・ｰ｢ｵｵ ﾁｦﾇﾑ

            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }

        // ｸｶｿ・ｺ ｽｺﾅｩｷﾑｷﾎ ﾁﾜ ﾀﾎ/ﾁﾜ ｾﾆｿ・
        float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        transform.position += transform.forward * scroll;

        // ｰ｡ｿ鋙･ ｸｶｿ・ｺ ｹｰﾀｸｷﾎ ﾆ・ﾀﾌｵｿ
        if (Input.GetMouseButton(2)) // ｰ｡ｿ鋙･ ｸｶｿ・ｺ ｹｰﾀｻ ｴｭｷｶﾀｻ ｶｧ ﾆ・ﾀﾌｵｿ
        {
            float panX = -Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            float panY = -Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;
            transform.Translate(new Vector3(panX, panY, 0), Space.Self);
        }
    }
}
