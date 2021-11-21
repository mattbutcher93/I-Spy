using UnityEngine;
using TMPro;
using System;

public class EnterNameUI : MonoBehaviour
{
    public event Action<string> OnNameEntered = delegate { };

    [SerializeField]
    private TMP_InputField nameInputField;

    private void Awake()
    {
        nameInputField.onEndEdit.AddListener(NameEntered);
    }

    private void NameEntered(string name)
    {
        nameInputField.interactable = false;
        OnNameEntered(name);
    }
}
