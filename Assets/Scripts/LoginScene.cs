using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginScene : MonoBehaviour
{
    [SerializeField] private TMP_InputField IDField;
    [SerializeField] private TMP_InputField NameField;
    [SerializeField] private TMP_InputField PassWardField;
    [SerializeField] private TMP_InputField PWConfirmField;

    private const string IDKey = "ID";
    private const string NameKey = "Name";
    private const string PWKey = "Password";

    private string IDValue;
    private string NameValue;
    private string PasswordValue;

    public void ConfirmBtn()
    {
        if (3 <= IDValue.Length && IDValue.Length <= 10) { }
    }
}
