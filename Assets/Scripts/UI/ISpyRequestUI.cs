using UnityEngine;
using TMPro;

public class ISpyRequestUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private ISpyController iSpyController;

    private void Awake()
    {
        iSpyController.OnISpyRequest += UpdateSpyRequestText;
    }

    private void UpdateSpyRequestText(SpyObjectData spyObjectData)
    {
        text.text = string.Format("I spy with my little eye, something beginning with: <color=\"orange\">{0}</color>", spyObjectData.name[0]);
    }

    private void OnDestroy()
    {
        iSpyController.OnISpyRequest -= UpdateSpyRequestText;
    }
}
