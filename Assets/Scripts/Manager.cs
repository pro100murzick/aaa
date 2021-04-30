using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] Rotator rotator;
    [SerializeField] PinSpawner pinSpawner;
    [SerializeField] CameraAnimator cameraAnimator;
    [SerializeField] int numberOfPins;
    private int currentNumberOfPins = 0;

    public int GetTotalNumberOfPins () { return numberOfPins; }

    public int GetCurrentNumberOfPins() { return currentNumberOfPins; }
    public void AddPin() { currentNumberOfPins++; }

     private void DisableGameElements()
    {
        rotator.enabled = false;
        pinSpawner.enabled = false;
    }
   public void GameOver(int sceneIndex)
    {
        DisableGameElements();
        PlayerPrefs.SetInt(Level.LAST_LEVEL_KEY, sceneIndex);
        cameraAnimator.SetGameOverTrigger();
    }
    public void LevelComplete(int sceneIndex)
    {
        DisableGameElements();
        int nextLevelIndex = PlayerPrefs.GetInt(Level.NEXT_LEVEL_KEY, Level.LEVEL_TO_START);
        if (sceneIndex >= nextLevelIndex)
        {
            PlayerPrefs.SetInt(Level.NEXT_LEVEL_KEY, sceneIndex + 1);
        }
        cameraAnimator.SetLevelComleteTrigger();
    }
}