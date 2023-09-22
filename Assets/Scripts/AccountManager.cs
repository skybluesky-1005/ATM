using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UserInfo
{
    public List<string[]> infoList;
    public int cash;
    public int banlnace;
}

public class AccountManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField newID;
    [SerializeField] private TMP_InputField newName;
    [SerializeField] private TMP_InputField newPW;
    [SerializeField] private TMP_InputField confirmPW;
    [SerializeField] private TextMeshProUGUI errorStr;

    [SerializeField] private TMP_InputField inputID;
    [SerializeField] private TMP_InputField inputPW;

    private const string MainScsene = "Main";

    string path;

    private void Start()
    {
        path = Path.Combine(Application.dataPath, "UserAccounts.json");
        errorStr.text = "";
    }

    public void CreatAccount()
    {
        UserInfo userInfo = new UserInfo();
        bool isIDExist = false;

        if (userInfo.infoList == null)
        {
            string[] infoArr = new string[3] { newID.text, newName.text, newPW.text };
            userInfo.infoList.Add(infoArr);
            userInfo.cash = 100000;
            userInfo.banlnace = 50000;

            string json = JsonUtility.ToJson(userInfo);

            File.WriteAllText(path, json);
        }
        else
        {
            for (int i = 0; i < userInfo.infoList.Count; i++)
            {
                if (userInfo.infoList[i][0] == newID.text)
                {
                    isIDExist = true;
                    break;
                }
            }
        }

        if (!isIDExist && newPW.text == confirmPW.text)
        {
            string[] infoArr = new string[3] { newID.text, newName.text, newPW.text };
            userInfo.infoList.Add(infoArr);
            userInfo.cash = 100000;
            userInfo.banlnace = 50000;

            string json = JsonUtility.ToJson(userInfo);

            File.WriteAllText(path, json);
        }
        else if (isIDExist)
            errorStr.text = "�̹� �����ϴ� ID�Դϴ�.";
        else if (newPW.text != confirmPW.text)
            errorStr.text = "��й�ȣ Ȯ�� ����";
    }

    public void LogIn()
    {
        UserInfo userInfo = new UserInfo();

        bool loginSucess = false;

        if (userInfo.infoList == null)
        {
            Debug.Log("��ϵ� ������ �����ϴ�. ������ �������ּ���");
            return;
        }

        for (int i = 0; i < userInfo.infoList.Count; i++)
        {
            if (userInfo.infoList[i][0] == inputID.text && 
                userInfo.infoList[i][2] == inputPW.text)
            {
                loginSucess = true;
                SceneManager.LoadScene(MainScsene);
            }
        }
        if (!loginSucess)
        {
            Debug.Log("ID/PW ����ġ. �ٽ� �Է��ϼ���");
        }
    }
}
