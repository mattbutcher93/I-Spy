using UnityEngine;
using TMPro;
using System.Collections;

public class GuessResultUI : MonoBehaviour
{
    [SerializeField]
    private float showTime = 2f;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private ISpyController iSpyController;

    private Coroutine showTextCoroutine;

    private void Awake()
    {
        iSpyController.OnGuess += GuessResult;
    }

    private void GuessResult(bool isCorrect)
    {
        if (showTextCoroutine != null)
        {
            StopCoroutine(showTextCoroutine);
        }

        showTextCoroutine = StartCoroutine(ShowTextTimed(isCorrect ? "<color=\"green\">Correct</color>"
                                                                   : "<color=\"red\">Incorrect</color>"));
    }

    private IEnumerator ShowTextTimed(string showText)
    {
        text.text = showText;
        yield return new WaitForSeconds(showTime);
        text.text = "";
        showTextCoroutine = null;
    }
}
