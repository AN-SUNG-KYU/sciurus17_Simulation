using UnityEngine;

public class MaintainScale : MonoBehaviour
{
    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        transform.localScale = initialScale;
    }
}
