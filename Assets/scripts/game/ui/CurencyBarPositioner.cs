using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class CurencyBarPositioner : MonoBehaviour
{
    [SerializeField]
    float m_iphoneXYPosition = 0f;

    private void Start()
    {
        if (UnityEngine.iOS.Device.generation == DeviceGeneration.iPhoneX)
        {
            var rect = GetComponent<RectTransform>();
            rect.localPosition = new Vector3(rect.localPosition.x, rect.localPosition.y + m_iphoneXYPosition, rect.localPosition.z);
            Debug.Log("moved Y pos");
        }
    }
}
