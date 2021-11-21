using UnityEngine;
using TMPro;

public class ISpyRequestUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textField;

    [SerializeField]
    private ISpyController iSpyController;

    private void Awake()
    {
        iSpyController.OnISpyRequest += UpdateSpyRequestText;
    }

    private void UpdateSpyRequestText(SpyObjectData spyObjectData)
    {
        textField.text = string.Format("I spy with my little eye, something beginning with: <color=\"orange\">{0}</color>", spyObjectData.name[0]);
    }

    private void OnDestroy()
    {
        iSpyController.OnISpyRequest -= UpdateSpyRequestText;
    }
}
