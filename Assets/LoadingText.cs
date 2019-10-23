using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingText : MonoBehaviour
{
    TMP_Text loadingText;
    void Start()
    {
        loadingText = GetComponent<TMP_Text>();
        StartCoroutine(UpdateLoadingText());
    }

    IEnumerator UpdateLoadingText()
    {
        while (true)
        {
            for (int i = 13; i < 17; i++)
            {
               
                loadingText.maxVisibleCharacters = i;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
