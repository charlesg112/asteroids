using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour, EventListener
{
    private Camera mainCam;
    private bool isShaking = false;
    void EventListener.onEvent(EventType eventType, GameObject source, int arg)
    {
        Debug.Log("Event received by camera manager");
        switch (eventType) {
            case EventType.AsteroidDestroyed:
                ShakeCamera();  break;
        }
    }
    void Start()
    {
        mainCam = Camera.main;
        EventBus.Subscribe(this);
    }

    private void ShakeCamera()
    {
        if (!isShaking) StartCoroutine(ShakeCameraCoroutine());
    }

    IEnumerator ShakeCameraCoroutine()
    {
        isShaking = true;
        Vector3 initialPos = mainCam.transform.position;
        Vector3 pos1 = initialPos + new Vector3(0.05f, 0.05f, 0);
        Vector3 pos2 = initialPos + new Vector3(-0.05f, 0.05f, 0);
        Vector3 pos3 = initialPos + new Vector3(-0.05f, -0.05f, 0);
        mainCam.transform.position = pos1;
        yield return new WaitForSeconds(0.05f);
        mainCam.transform.position = pos2;
        yield return new WaitForSeconds(0.05f);
        mainCam.transform.position = pos3;
        yield return new WaitForSeconds(0.05f);
        mainCam.transform.position = initialPos;
        isShaking = false;
    }
}
