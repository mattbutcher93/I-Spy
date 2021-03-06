using UnityEngine;
using TMPro;
using System.Collections;

public class GuessResultUI : MonoBehaviour
{
    [SerializeField]
    private float showTime = 2f;

    [SerializeField]
    private TextMeshProUGUI textField;

    [SerializeField]
    private ISpyController iSpyController;

    private Coroutine showTextCoroutine;

    private void Awake()
    {
        iSpyController.OnGuess += GuessResult;
    }

    private void GuessResult(bool isCorrect, string name)
    {
        if (showTextCoroutine != null)
        {
            StopCoroutine(showTextCoroutine);
        }

        showTextCoroutine = StartCoroutine(ShowTextTimed(isCorrect ? "<color=\"green\">Correct</color>\n<color=\"white\">" + name + "</color>"
                                                                   : "<color=\"red\">Incorrect</color>"));
    }

    private IEnumerator ShowTextTimed(string showText)
    {
        textField.text = showText;
        yield return new WaitForSeconds(showTime);
        textField.text = "";
        showTextCoroutine = null;
    }
}
