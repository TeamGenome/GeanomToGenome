using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private Text generationText;
    [SerializeField] private Text genomListText;
    private StringBuilder generation = new StringBuilder("Generation : 0");
    private StringBuilder dominantGenom = new StringBuilder("Dominant Genom : 00000000");

    void Start()
    {
        FindObjectOfType<GenomManager>().generationUpdateEvent += SetGenerationUI;
        SetUI();
    }

    void SetGenerationUI(int gen, List<bool> genom)
    {
        // set generation string
        generation.Remove(13, generation.Length - 13);
        generation.Append(gen);

        // set dominant string
        dominantGenom.Remove(17, dominantGenom.Length - 17);
        for(int i = 0; i < genom.Count; i++){
            dominantGenom.Append(genom[i] ? 1 : 0);
            if(i % 4 == 0)
                dominantGenom.Append(" ");
        }


        // set UI
        SetUI();

    }

    void SetUI()
    {
        generationText.text = generation.ToString();
        genomListText.text = dominantGenom.ToString();
    }
}
