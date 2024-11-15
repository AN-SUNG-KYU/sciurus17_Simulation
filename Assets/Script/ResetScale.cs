using UnityEngine;

public class ResetScale : MonoBehaviour
{
    public void ResetToUnitScale()
    {

        Vector3 currentWorldScale = transform.lossyScale;


        Vector3 parentWorldScale = transform.parent != null ? transform.parent.lossyScale : Vector3.one;


        transform.localScale = new Vector3(
            currentWorldScale.x / parentWorldScale.x,
            currentWorldScale.y / parentWorldScale.y,
            currentWorldScale.z / parentWorldScale.z
        );
    }
}
