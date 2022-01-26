using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class MouseSensivity : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;

    public void ChangeMouseSensivity()
    {
        cam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = GetComponent<Slider>().value;
        cam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = GetComponent<Slider>().value;
    }
}
