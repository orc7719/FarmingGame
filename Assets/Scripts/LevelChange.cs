using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelChange : MonoBehaviour
{
    public GameObject LevelSelect;
    public GameObject Credits;

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
}
