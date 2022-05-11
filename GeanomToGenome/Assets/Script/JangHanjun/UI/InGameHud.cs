using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class InGameHud : MonoBehaviour
{
    [SerializeField] protected Text generationText;
    [SerializeField] protected Text genomListText;
    protected StringBuilder generation = new StringBuilder("Generation : 0");
    protected StringBuilder dominantGenom = new StringBuilder("Dominant Genom : 00000000");



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
}
