using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    [SerializeField] Animator[] winningPanelsAnim;
    [SerializeField] GameObject coin;
    [SerializeField] GameObject[] Buttons;
    [SerializeField] GameObject spinAgainBtn;
    private void Start()
    {
        if (audio.mute)
        {
            audioBtn.image.sprite = audioON;
        }
        else
        {
            audioBtn.image.sprite = audioOFF;
            
        }
    }
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

            coin.SetActive(true);
            coin.GetComponent<Animator>().enabled = true;
            foreach (GameObject gb in Buttons)
            {
                gb.SetActive(false);
            }

            foreach(Animator anim in winningPanelsAnim)
            {
                anim.SetBool("Start", true);
                
            }
            

            StartCoroutine(Anim());

        }
    }
    public void spin()
    {
        coin.SetActive(false);
        foreach (Animator anim in winningPanelsAnim)
        {
            anim.SetBool("End", false);
        }
    }
    public void onEnter()
    {
        if (!winnerPanel.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("fadein"))
        {
            //winnerPanel.GetComponent<Animator>().enabled = false;
           // winnerImage.gameObject.GetComponent<Animator>().SetBool("hover", true);
        }
    }
    public void onExit()
    {
       
            Debug.Log("Sll");
            winnerPanel.GetComponent<Animator>().enabled = true;
            winnerImage.gameObject.GetComponent<Animator>().SetBool("hover", false);
        
    }
    public void SpinAgainClick()
    {
       
        spinAgainBtn.SetActive(false);
        winnerPanel.SetActive(false);
        coin.SetActive(true);
        coin.GetComponent<SpriteRenderer>().sortingOrder = 2;
       
        winnerPanel.GetComponent<Animator>().enabled = true;
        foreach (GameObject gb in Buttons)
        {
            gb.SetActive(true);
        }

        foreach (Animator anim in winningPanelsAnim)
        {
            anim.SetBool("Start", false);

        }
        foreach (Animator anim in winningPanelsAnim)
        {
            anim.SetBool("End", true);
        }
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
    IEnumerator Anim()
    {
        yield return new WaitForSeconds(0.9f);
        coin.GetComponent<SpriteRenderer>().sortingOrder = 5;
        int temp = Random.Range(0, 50);
        winnerPanelImage.color = platazees[temp].texture.GetPixel(10, 10);
        Debug.Log($"{temp  }    " + platazees[temp].texture.GetPixel(10, 10));
        

        winnerImage.sprite = platazees[temp];
        winnerPanel.SetActive(true);
        spinAgainBtn.SetActive(true);
        yield return new WaitForSeconds(2f);

        coin.GetComponent<Animator>().SetBool("Start", false);
        winnerPanel.GetComponent<Animator>().SetBool("onhover", true);
        coin.SetActive(false);
        coin.GetComponent<SpriteRenderer>().sortingOrder = 2;
        

    }
    public void enter(TMP_Text tmp)
    {
        if (Buttons[0].GetComponent<Button>().interactable)
        {
            tmp.color = Color.black;
        }
        
    }
    public void exit(TMP_Text tmp)
    {

        if (Buttons[0].GetComponent<Button>().interactable)
        {
            tmp.color = Color.white;
        }
    }

}
