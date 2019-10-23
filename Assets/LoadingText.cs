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
            for (int i = 6; i < 10; i++)
            {
               
                loadingText.maxVisibleCharacters = i;
                yield return new WaitForSeconds(0.4f);
            }
        }
    }
}
