using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacterWindow : MonoBehaviour
{
    [SerializeField] SwimMessagePanel messagePanel;
    [Space(10)]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip errorAudioClicp;
    [Space(10)]
    [SerializeField] Text nameText, surnameText, companyNameText;
    [SerializeField] Text actionPanelNameText, actionPanelSurnameText, actionPanelCompanyNameText;
    [Space(10)]
    [SerializeField] Text nameErrorText, surnameErrorText, companyNameErrorText;
    [Space(10)]
    [SerializeField] Slider loanSlider;


    public void CreateCharacter()
    {
        if (FieldsAreFull())
        {
            messagePanel.SpawnMessage("It became known that" + nameText.text + " " + nameText.text + 
                " has created a new company(" +
                companyNameText.text + ")to create games. " +
                "Will the company become a money-making pipeline or a new folk developer? We will see soon!");

            actionPanelNameText.text = nameText.text;
            actionPanelSurnameText.text = surnameText.text;
            actionPanelCompanyNameText.text = companyNameText.text;

            ActionPanel.AddMoney(((int)loanSlider.value));

            Destroy(gameObject);
        }
        else return;
    }

    bool FieldsAreFull()
    {
        bool isFull = true;

        if (nameText.text == "")
        {
            ShowErrorText(nameErrorText.gameObject);
            isFull = false;
        }

        if (surnameText.text == "")
        {
            ShowErrorText(surnameErrorText.gameObject);
            isFull = false;
        }

        if(companyNameText.text == "")
        {
            ShowErrorText(companyNameErrorText.gameObject);
            isFull = false;
        }

        return isFull;
    }

    void ShowErrorText(GameObject errorText)
    {
        audioSource.PlayOneShot(errorAudioClicp);
        errorText.SetActive(true);
    }
}