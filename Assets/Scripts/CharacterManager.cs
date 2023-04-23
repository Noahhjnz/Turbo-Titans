using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDatabase;
    public Text nametext;
    public SpriteRenderer artworksSprite;

    private int selectedOption = 0;

    void Start()
    {

        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;

        if (selectedOption >= characterDatabase.CharacterCount)
        {
            selectedOption = 0;

        }
        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDatabase.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDatabase.GetCharacter(selectedOption);
        artworksSprite.sprite = character.characterSprite;

    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    
   
}
