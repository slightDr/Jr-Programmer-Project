using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.instance.TeamColor = color;
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
        ColorPicker.SelectColor(MainManager.instance.TeamColor);
    }
    
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Exit()
    {
        MainManager.instance.SaveColor();
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }
    
    // 测试用函数
    public void SaveColorClicked()
    {
        MainManager.instance.SaveColor();
    }

    public void LoadColorClicked()
    {
        MainManager.instance.LoadColor();
        ColorPicker.SelectColor(MainManager.instance.TeamColor);
    }
}
