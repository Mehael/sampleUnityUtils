using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelManager
{
    private const string LevelNameTemplate = "Level";
    private const string ClipNameTemplate = "Clip";
    private static int savedLevel;
    private static int currentLevel;
    private static int currentClip;

    public static bool HaveSavedLevel
    {
        get { return savedLevel != 0; }
    }

    private static string GetLevelName(int index)
    {
        return LevelNameTemplate + " " + index;
    }

    private static string GetClipName(int index)
    {
        return ClipNameTemplate + " " + index;
    }

    private static string nameBuffer;
    private static bool isLoading;
    private static void LoadScene(string name)
    {
        if (isLoading) return;
        nameBuffer = name;
        isLoading = true;
        FadeManager.Fade(PostFadeLoadScene);
    }

    public static void PostFadeLoadScene()
    {
        Application.LoadLevel(nameBuffer);
        FadeManager.Unfade(PostUnfadeLoadScene);
    }

    public static void PostUnfadeLoadScene()
    {
        isLoading = false;
    }

    public static void NextLevel()
    {
        if (isLoading) return;
        LoadScene(GetLevelName(++currentLevel));
    }

    public static void NextClip()
    {
        if (isLoading) return;
        LoadScene(GetClipName(++currentClip));
    }

    public static void RestartLevel()
    {
        if (isLoading) return;
        LoadScene(GetLevelName(currentLevel));
    }

    public static void Save()
    {
        savedLevel = currentLevel+1;
    }

    public static void Load()
    {
        if (isLoading) return;
        if (!HaveSavedLevel) return;
        currentLevel = savedLevel;
        currentClip = savedLevel-1;
        LoadScene(GetLevelName(savedLevel));
    }

    public static void NewGame()
    {
        if (isLoading) return;
        currentLevel = 0;
        currentClip = 0;
        savedLevel = 1;
        LoadScene(GetClipName(0));
    }

    public static void MainMenu()
    {
        if (isLoading) return;
        currentLevel = 0;
        currentClip = 0;
        LoadScene("MainMenu");
    }

    public static void DefeatClip()
    {
        if (isLoading) return;
        LoadScene("Defeat Clip");
    }

    public static void Exit()
    {
        Application.Quit();
    }
}