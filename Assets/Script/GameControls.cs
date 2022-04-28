using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls : MonoBehaviour
{

    [SerializeField] GameObject[] sroll;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameManager gameManager;
    [SerializeField] Animator anim;
    [SerializeField] Button btn;
    [SerializeField] bool perfectScore = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void onClick()
    {
        btn.interactable = false;
        anim.SetTrigger("Use");
        audioSource.PlayOneShot(audioClips[0]);
        StartCoroutine(ExecuteAfterTime());
    }
    IEnumerator ExecuteAfterTime()
    {
        if (perfectScore)
        {
            int temp = Random.Range(0, 3);
            foreach (GameObject gameObject in sroll)
            {
                gameObject.GetComponent<ScollToDraw>().canStart = true;
                gameObject.GetComponent<ScollToDraw>().stopNow = false;
                gameManager.GetComponent<GameManager>().winnerPnale(false);

                gameObject.GetComponent<ScollToDraw>().numbers = temp;
                yield return new WaitForSeconds(.3f);
            }
        }
        else
        {
            foreach (GameObject gameObject in sroll)
            {
                gameObject.GetComponent<ScollToDraw>().canStart = true;
                gameObject.GetComponent<ScollToDraw>().stopNow = false;
                gameManager.GetComponent<GameManager>().winnerPnale(false);
                int temp = Random.Range(0, 7);
                gameObject.GetComponent<ScollToDraw>().numbers = GetRandomNumber(temp);
                yield return new WaitForSeconds(.3f);
            }
        }
       

        yield return new WaitForSeconds(.5f);
        StartCoroutine(StopRunning());
    }

    IEnumerator StopRunning()
    {
        foreach (GameObject gameObject in sroll)
        {
            
            gameObject.GetComponent<ScollToDraw>().stopNow = true;
            yield return new WaitForSeconds(.3f);
        }
        yield return new WaitForSeconds(.1f);
        if ((sroll[0].GetComponent<ScollToDraw>().numbers == sroll[1].GetComponent<ScollToDraw>().numbers)&& (sroll[1].GetComponent<ScollToDraw>().numbers == sroll[2].GetComponent<ScollToDraw>().numbers)){
            audioSource.PlayOneShot(audioClips[1]);
            gameManager.GetComponent<GameManager>().winnerPnale(true);
        }
        else
        {
            audioSource.PlayOneShot(audioClips[2]);
        }
        btn.interactable = true;

    }
    int GetRandomNumber(int temp)
    {

       
            if (temp > 2)
            {
                return 1;
            }
            else
            {
                return temp;
            }
        

        
    }
}
