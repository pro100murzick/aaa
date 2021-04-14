using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] Rotator rotator;
    [SerializeField] PinSpawner pinSpawner;
    [SerializeField] CameraAnimator cameraAnimator;

     private void DisableGameElements()
    {
        rotator.enabled = false;
        pinSpawner.enabled = false;
    }
   public void GameOver()
    {
        DisableGameElements();
        cameraAnimator.SetGameOverTrigger();
    }
    public void LevelComplete()
    {
        DisableGameElements();
        cameraAnimator.SetLevelComleteTrigger();
    }
}