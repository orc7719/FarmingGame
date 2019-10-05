using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using ScriptableObjectArchitecture;

public class MainMenuScript : MonoBehaviour
{
    public GameObject LevelSelect;
    public GameObject Credits;
    public Slider VolumeSlider;
    public AudioMixer masterAudio;
    public GameObject ExitButton;
    public LevelSelectionSetup levelList;
    public SceneVariable tutorialScene;

    void Start()
    {
        VolumeSlider.value = -30f;
    }

    // Update is called once per frame
    public void ToggleLevelSelect(bool newstate)
    {
        LevelSelect.SetActive(newstate);
        levelList.UpdateLevelList();
    }
    public void ToggleCredits(bool newstate1)
    {
        Credits.SetActive(newstate1);
    }

    public void ChangeVolume()
    {
        masterAudio.SetFloat("Master", VolumeSlider.value);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadTutorial()
    {
        GameManager.Instance.LoadLevel(tutorialScene);
    }
}
