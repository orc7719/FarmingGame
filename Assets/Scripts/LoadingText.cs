using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingText : MonoBehaviour
{
    TMP_Text loadingText;
    void OnEnable()
    {
        loadingText = GetComponent<TMP_Text>();
        StartCoroutine(UpdateLoadingText());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator UpdateLoadingText()
    {
        while (true)
        {
            for (int i = 7; i < 11; i++)
            {
               
                loadingText.maxVisibleCharacters = i;
                yield return new WaitForSeconds(0.4f);
            }
        }
    }
}
