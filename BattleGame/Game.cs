using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public List<GameObject> bullets = new List<GameObject>();
    public int shots = 0;
    public int hits = 0;

    [SerializeField]
    private Text hitsText;
    [SerializeField]
    private Text shotsText;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject[] targets;
    private bool isPaused = false;

    private void Awake()
    {
        Pause();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Pause()
    {
        menu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Unpause()
    {
        menu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        isPaused = false;
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    public void SaveGame()
    {

    }

    public void NewGame()
    {
        hits = 0;
        shots = 0;
        shotsText.text = "Shots: " + shots;
        hitsText.text = "Hits: " + hits;

        ClearRobots();
        ClearBullets();
        RefreshRobots();

        Unpause();
    }

    private void ClearRobots()
    {
        foreach (GameObject target in targets)
        {
            target.GetComponent<Target>().DisableRobot();
        }
    }

    private void ClearBullets()
    {
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
    }

    private void RefreshRobots()
    {
        foreach (GameObject target in targets)
        {
            target.GetComponent<Target>().RefreshTimers();
        }
    }

    public void AddShot()
    {
        shots++;
        shotsText.text = "Shots: " + shots;
    }

    public void AddHit()
    {
        hits++;
        hitsText.text = "Hits: " + hits;
    }

    public void LoadGame()
    {

    }

    public void SaveAsJSON()
    {

    }
}

