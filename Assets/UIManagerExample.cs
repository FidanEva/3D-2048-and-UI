

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class UIManagerExample : MonoBehaviour
{
    public static UIManager instance;

    [Header("General Panel")]
    [SerializeField] GameObject GeneralPanel;

    [Header("Home Panel")]
    [SerializeField] GameObject HomePanel;
    [SerializeField] TMP_Text TapToPlay;

    [Header("Settings Panel")]
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject SettingsUIPanel;

    [Header("Win Panel")]
    [SerializeField] GameObject WinlPanel;

    [Header("Fail Panel")]
    [SerializeField] GameObject FailPanel;



    // private void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //     }
    // }

    private void Start()
    {
        OpenHomePanel();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OpenSettingsPanel();
        }
    }

    //////// General Panel ///////
    public void OpenGeneralPanel()
    {
        GeneralPanel.SetActive(true);
    }
    public void CloseGeneralPanel()
    {
        GeneralPanel.SetActive(false);
    }

    //////// Home Panel ///////
    public void OpenHomePanel()
    {
        HomePanel.SetActive(true);
        TapToPlay.transform.DOScale(1.3f, 1).SetLoops(-1, LoopType.Yoyo);

    }
    public void CloseHomePanel()
    {
        HomePanel.SetActive(false);
    }
    //////// Settings Panel ///////
    public void OpenSettingsPanel()
    {
        SettingsPanel.SetActive(true);
        SettingsUIPanel.SetActive(true);
        SettingsUIPanel.transform.localScale = Vector3.zero;
        Image panelImg = SettingsPanel.GetComponent<Image>();
        panelImg.color = new Color(0, 0, 0, 0);
        DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 180), 0.2f);
        SettingsUIPanel.transform.DOScale(0.7f, 0.2f);
    }
    public void CloseSettingsPanel()
    {

        // 
        Image panelImg = SettingsPanel.GetComponent<Image>();
        DOTween.To(() => panelImg.color, x => panelImg.color = x, new Color32(32, 32, 32, 0), 0.2f);
        SettingsUIPanel.transform.DOScale(0f, 0.2f).OnComplete(() =>
        {
            SettingsPanel.SetActive(false);
            SettingsUIPanel.SetActive(false);
        });
    }

    //////// Win Panel ///////
    public void OpenWinPanel()
    {
        WinlPanel.SetActive(true);
    }
    public void CloseWinPanel()
    {
        WinlPanel.SetActive(false);
    }
    //////// Win Panel ///////
    public void OpenFailPanel()
    {
        FailPanel.SetActive(true);
    }
    public void CloseFailPanel()
    {
        FailPanel.SetActive(false);
    }
}