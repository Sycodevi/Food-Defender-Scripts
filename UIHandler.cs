using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Player player;
    public Objective objective;

    public Button MenuButton;
    public Button MenuCloseButton;
    public Button MainMenu, MainMenu2, Quit, Mainmenu3, Restart, NextLevel;

    public TextMeshProUGUI EnemyCountText;
    public TextMeshProUGUI HealthAmountText;

    public Slider HealthSlider;

    public GameObject Enemies;
    public GameObject MenuPanel;
    public GameObject levelOverPanel, levelLostPanel;
    public GameObject DynamicJoystick;

    MainMenuController MMC;

    private bool levelStatus = true;

    private void Start()
    {
        MMC = new MainMenuController();
        HealthSlider.minValue = 0; HealthSlider.maxValue = 100;
        HealthSlider.value = objective.TotalHealth;
        MenuButton.onClick.AddListener(MenuHandler);
        MenuCloseButton.onClick.AddListener(MenuHandler);
        MainMenu.onClick.AddListener(MainMenuBtnHandler);
        MainMenu2.onClick.AddListener(MainMenuBtnHandler);
        Quit.onClick.AddListener(QuitHandler);
        Mainmenu3.onClick.AddListener(MainMenuBtnHandler);
        Restart.onClick.AddListener(RestartHandler);
        NextLevel.onClick.AddListener(NextLevelHandler);
    }

    private void NextLevelHandler()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void RestartHandler()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateHealth()
    {
        HealthAmountText.text = objective.currentHealth + "/" + objective.TotalHealth;
        HealthSlider.value = objective.currentHealth;
        if(HealthSlider.value <= 0)
        {
            levelLostPanel.SetActive(true);
            DynamicJoystick.SetActive(false);
            levelStatus = false;
            Time.timeScale = 0;
        }
    }

    private void QuitHandler()
    {
        Application.Quit();
    }

    private void MainMenuBtnHandler()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    private void MenuHandler()
    {
        if(MenuPanel.activeInHierarchy == false)
        {
            MenuPanel.SetActive(true);
            DynamicJoystick.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            MenuPanel.SetActive(false);
            DynamicJoystick.SetActive(true);
            Time.timeScale = 1;
        }
    }

    private void FixedUpdate()
    {
        UpdateEnemyCount();
    }

    public void UpdateEnemyCount()
    {
        if (Enemies.transform.childCount <= 0 && levelStatus == true)
        {
            MMC.SaveGame(SceneManager.GetActiveScene().buildIndex + 1);
            levelOverPanel.SetActive(true);
            DynamicJoystick.SetActive(false);
            levelStatus = false;
            Time.timeScale = 0;
        }
        EnemyCountText.text = Enemies.transform.childCount.ToString();
    }
}
