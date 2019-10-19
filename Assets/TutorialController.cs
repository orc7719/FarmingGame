using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialController : Singleton<TutorialController>
{
    [Header("State Info")]
    Animator anim;

    [Header("UI Components")]
    [SerializeField] GameObject tutorialDisplay = null;
    [SerializeField] TMP_Text tutorialText = null;
    [SerializeField] GameObject itemDisplay = null;
    [SerializeField] Image itemSprite = null;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            anim.SetTrigger("OnClick");
    }

    public void UpdateTutorialUI(string newDialogue, Sprite newItemSprite)
    {
        ResetTriggers();

        StopCoroutine("DisplayText");
        StartCoroutine("DisplayText", newDialogue);

        itemDisplay.SetActive(newItemSprite != null);

        if (newItemSprite != null)
            itemSprite.sprite = newItemSprite;
    }

    void ResetTriggers()
    {
        anim.ResetTrigger("OnClick");
        anim.ResetTrigger("OnCollectWater");
        anim.ResetTrigger("OnWaterField");
        anim.ResetTrigger("OnCollectSeeds");
        anim.ResetTrigger("OnPlantSeeds");
        anim.ResetTrigger("OnHarvestCrop");
        anim.ResetTrigger("OnSellCrop");
        anim.ResetTrigger("OnHelpButton");
        anim.ResetTrigger("OnItemBinned");
        anim.ResetTrigger("OnCropDeath");
    }

    IEnumerator DisplayText(string newText)
    {
        tutorialText.text = newText;
        tutorialText.maxVisibleCharacters = 0;

        yield return new WaitForSeconds(0.25f);

        for (int i = 0; i < newText.Length; i++)
        {
            tutorialText.maxVisibleCharacters += 1;
            yield return new WaitForSeconds(0.03f);
        }
    }
}
