using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    private const string cashKey = "cash";
    private const string banlanceKey = "banlance";
    private const string DespoitScene = "Despoit";
    private const string WithdrawalScene = "Withdrawal";

    private int cashValue;
    private int banlanceValue;

    public TextMeshProUGUI cashText;
    public TextMeshProUGUI banlanceText;

    private void Awake()
    {
        if (PlayerPrefs.GetInt(cashKey) + PlayerPrefs.GetInt(banlanceKey) != 150000)
        {
            PlayerPrefs.SetInt(cashKey, 100000);
            PlayerPrefs.SetInt(banlanceKey, 50000);
            PlayerPrefs.Save();
        }
    }

    private void Start()
    {
        cashValue = PlayerPrefs.GetInt(cashKey);
        banlanceValue = PlayerPrefs.GetInt(banlanceKey);

        cashText.text = cashValue.ToString("N0");
        banlanceText.text = banlanceValue.ToString("N0");
    }

    public void DespoitBtn()
    {
        SceneManager.LoadScene(DespoitScene);
    }

    public void WithdrawalBtn()
    {
        SceneManager.LoadScene(WithdrawalScene);
    }
}
