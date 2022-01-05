using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class MouseSensivity : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook cam;

    public void ChangeMouseSensivity()
    {
        cam.m_XAxis.m_MaxSpeed = GetComponent<Slider>().value;
    }
}
