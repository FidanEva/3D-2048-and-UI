using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject HomePanel;
    [SerializeField] GameObject PlayModePanel;
    [SerializeField] GameObject GeneralPanel;
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject FailPanel;
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject ShopPanel;
    [SerializeField] GameObject DailyRewardPanel;
    [SerializeField] Slider _volumeSlider;

     void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            OpenWin();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            OpenFail();
        }
    }

    public void ActiveHome()
    {
        HomePanel.SetActive(true);
        GeneralPanel.SetActive(true);
    }

    public void StartGame()
    {
        HomePanel.SetActive(false);
        PlayModePanel.SetActive(true);
        Invoke("OpenDailyReward", 1);
    }

    public void OpenSettings()
    {
        SettingsPanel.SetActive(true);
        OpeningPopup(SettingsPanel.transform.GetChild(1).gameObject);
        
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
    }

    public void OpenShop()
    {
        ShopPanel.SetActive(true);
        OpeningPopup(ShopPanel.transform.GetChild(0).gameObject);

    }

    public void CloseShop()
    {
        ShopPanel.SetActive(false);
    }

    public void OpenDailyReward()
    {
        DailyRewardPanel.SetActive(true);
        OpeningPopup(DailyRewardPanel.transform.GetChild(1).gameObject);
    }

    public void CloseDailyReward()
    {
        DailyRewardPanel.SetActive(false);
    }

    public void OpenWin()
    {
        WinPanel.SetActive(true);
        OpeningPopup(WinPanel.transform.GetChild(1).gameObject);
    }
    public void CloseWin()
    {
        WinPanel.SetActive(false);
        StartGame();
    }
    public void OpenFail()
    {
        FailPanel.SetActive(true);
        OpeningPopup(FailPanel.transform.GetChild(1).gameObject);
    }
    public void CloseFail()
    {
        FailPanel.SetActive(false);
        StartGame();
    }

    void OpeningPopup(GameObject panel)
    {
        var seq = DOTween.Sequence();
        seq.Append(panel.transform.DOShakeScale(0.3f, 0.1f));
    }

    public void ChangeVolume()
    {
        AudioListener.volume = _volumeSlider.value;
        SaveVolume();
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", _volumeSlider.value);
    }

    public void LoadVolume()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
