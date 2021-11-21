using UnityEngine;
using TMPro;

public class SubmitGuessUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textField;

    [SerializeField]
    private ISpyController iSpyController;

    [SerializeField]
    private ObjectSelector objectSelector;


    private void Awake()
    {
        objectSelector.OnObjectSelected.AddListener(ShowSubmitGuessText);
        objectSelector.OnObjectDeselected.AddListener(HideSubmitGuessText);
        textField.text = "";
    }

    private void ShowSubmitGuessText()
    {
        textField.text = string.Format("Press {0} to submit guess", iSpyController.SubmitGuessKey);
    }

    private void HideSubmitGuessText()
    {
        textField.text = "";
    }
}
