using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject whatsGoingOnPanel;
    [SerializeField] GameObject winnerPanel;
    [SerializeField] Sprite[] platazees;
    [SerializeField] Image winnerImage;
    [SerializeField] Image winnerPanelImage;
    [SerializeField] AudioSource audio;
    [SerializeField] Button audioBtn;
    [SerializeField] Sprite audioON;
    [SerializeField] Sprite audioOFF;
    public  void ClosePanel()
    {
        whatsGoingOnPanel.SetActive(false);
    }
    public void OpenPanel()
    {
        whatsGoingOnPanel.SetActive(true);
    }
    public void winnerPnale(bool winner)
    {

        if (winner == true)
        {

        int temp = Random.Range(0, 50);
            winnerPanelImage.color = platazees[temp].texture.GetPixel(10, 10);
            Debug.Log($"{temp  }    " +platazees[temp].texture.GetPixel(10, 10));
            winnerImage.sprite = platazees[temp];
        }
       
        winnerPanel.SetActive(winner);
    }
    public void onEnter()
    {
        if (!winnerPanel.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("fadein"))
        {
            winnerPanel.GetComponent<Animator>().enabled = false;
            winnerImage.gameObject.GetComponent<Animator>().SetBool("hover", true);
        }
    }
    public void onExit()
    {
       
            Debug.Log("Sll");
            winnerPanel.GetComponent<Animator>().enabled = true;
            winnerImage.gameObject.GetComponent<Animator>().SetBool("hover", false);
        

    }
    public void MusicOnOff()
    {
        if (audio.mute)
        {
            audioBtn.image.sprite = audioOFF;
            audio.mute = false;
        }
        else
        {
            audioBtn.image.sprite = audioON;
            audio.mute = true;
        }
    }
}
