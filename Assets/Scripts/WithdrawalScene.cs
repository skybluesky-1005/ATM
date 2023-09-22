using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WithdrawalScene : MonoBehaviour
{
    private const string cashKey = "cash";
    private const string banlanceKey = "banlance";
    private const string MainScsene = "Main";

    private int cashValue;
    private int banlanceValue;

    [SerializeField] private TextMeshProUGUI cashText;
    [SerializeField] private TextMeshProUGUI banlanceText;
    [SerializeField] private TMP_InputField userInput;
    [SerializeField] private GameObject popUp;

    private void Awake()
    {
        cashValue = PlayerPrefs.GetInt(cashKey);
        banlanceValue = PlayerPrefs.GetInt(banlanceKey);
    }

    private void Start()
    {
        popUp.SetActive(false);
        Renewal();
    }

    public void InputBtn(int amount)
    {
        if (banlanceValue < amount)
        {
            popUp.SetActive(true);
            return;
        }
        PlayerPrefs.SetInt(banlanceKey, banlanceValue - amount);
        PlayerPrefs.SetInt(cashKey, cashValue + amount);
        banlanceValue -= amount;
        cashValue += amount;
        Renewal();
    }

    public void CustomInputBtn()
    {
        InputBtn(int.Parse(userInput.text));
    }

    public void ClosePopUp()
    {
        popUp.SetActive(false);
    }

    public void CancleBtn()
    {
        SceneManager.LoadScene(MainScsene);
    }

    private void Renewal()
    {
        cashText.text = cashValue.ToString("N0");
        banlanceText.text = banlanceValue.ToString("N0");
        PlayerPrefs.Save();
    }
}
