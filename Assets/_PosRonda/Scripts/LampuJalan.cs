using UnityEngine;

public class LampuJalan : MonoBehaviour
{
    public Light pointLight;

    public void MatikanLampu()
    {
        if (pointLight != null)
        {
            pointLight.enabled = false;
        }
    }
}