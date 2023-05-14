using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public GameObject[] skins2;
    public int selectedCharacter;
    public int selectedCharacter2;
    public bool MultiMode = true;

    private void Awake()
    {
        PlayerManager.MultiMode = this.MultiMode;
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        selectedCharacter2 = PlayerPrefs.GetInt("SelectedCharacter2", 0);
        foreach (GameObject player in skins)
            player.SetActive(false);
       

         skins[selectedCharacter].SetActive(true);
            if (MultiMode) { 
        
        foreach (GameObject player in skins2)
        player.SetActive(false);
        skins2[selectedCharacter2].SetActive(true);
        }
    }
    public void ChangeNext()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == skins.Length)
            selectedCharacter = 0;

        skins[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }

    public void ChangePrevious()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter --;
        if (selectedCharacter == -1)
            selectedCharacter = skins.Length - 1;

        skins[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }
    public void ChangeNext2()
    {
        skins2[selectedCharacter2].SetActive(false);
        selectedCharacter2 ++;
        if (selectedCharacter2 == skins2.Length)
            selectedCharacter2 = 0;
        
        skins2[selectedCharacter2].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter2", selectedCharacter2);
    }

    public void ChangePrevious2()
    {
        skins2[selectedCharacter2].SetActive(false);
        selectedCharacter2 --;
        if (selectedCharacter2 == -1)
            selectedCharacter2 = skins2.Length - 1;

        skins2[selectedCharacter2].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter2", selectedCharacter2);
    }


}
