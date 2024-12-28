using TMPro;
using UnityEngine;

public class TextToIntConverter : MonoBehaviour
{
    private int convertedInt;

    public int GetIntFromText(TextMeshProUGUI textMeshPro)
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshProUGUI component is not assigned!");
            return 0;
        }

        string text = textMeshPro.text;

        if (int.TryParse(text, out convertedInt))
        {
            Debug.Log("Text converted to int: " + convertedInt);
            return convertedInt;
        }
        else
        {
            Debug.LogError("Failed to convert text to int. Invalid format: " + text);
            return 0;
        }
    }
}
