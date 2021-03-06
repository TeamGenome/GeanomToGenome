using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System;

public class InGameHud : MonoBehaviour
{
    [SerializeField] protected Text generationText;
    [SerializeField] protected Text genomListText;
    protected StringBuilder generation = new StringBuilder("Generation : 0");
    protected StringBuilder dominantGenom = new StringBuilder("Dominant Genom : 00000000");


    // [Header("input field")]
    public event Action<int> inputGenomEvent;
    [SerializeField] private InputField genomInputField;

    // [Header("final selection")]
    public event Action<int> inputFinalGenomEvent;
    [SerializeField] private InputField finalGenomSelectField;

    // [Header("continue panel")]
    [SerializeField] private GameObject selectContinuePanel;





    public void SetGenerationUI(int gen, StringBuilder genom)
    {
        // set generation string
        generation.Remove(13, generation.Length - 13);
        generation.Append(gen);

        // set dominant string
        dominantGenom.Remove(17, dominantGenom.Length - 17);
        dominantGenom.Append(genom);

        // set UI
        SetUI();
    }

    private void SetUI()
    {
        generationText.text = generation.ToString();
        genomListText.text = dominantGenom.ToString();
    }

    public void EndInputEvent()
    {
        int index;
        if(int.TryParse(genomInputField.text, out index))
        {
            inputGenomEvent?.Invoke(index);
        }
    }

    public void EndFinalGenomInputEvent()
    {
        Debug.Log(finalGenomSelectField.text);
        int index;
        if(int.TryParse(finalGenomSelectField.text, out index))
        {
            inputFinalGenomEvent?.Invoke(index);
        }

        OpenContinuePanel();
    }

    public void OpenContinuePanel()
    {
        Time.timeScale = 0f;
        selectContinuePanel.SetActive(true);
    }

    public void ContinueTraining()
    {
        Time.timeScale = 1f;
        selectContinuePanel.SetActive(false);
    }

    public void StopTraining()
    {
        SceneManager.LoadScene(0);
    }   

}
