using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MainMenuScript : MonoBehaviour
{
    public GameObject LevelSelect;
    public GameObject Credits;
    public Slider VolumeSlider;
    public AudioMixer masterAudio;
    // Update is called once per frame
    public void ToggleLevelSelect(bool newstate)
    {
        LevelSelect.SetActive(newstate);
      //SceneManager.LoadScene( "InteractionScene") ;
      
    }
    public void ToggleCredits(bool newstate1)
    {
        Credits.SetActive(newstate1);
    }

    public void ChangeVolume()
    {
        masterAudio.SetFloat("Master", VolumeSlider.value);
    }
}
