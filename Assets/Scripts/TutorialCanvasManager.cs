using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialCanvasManager : MonoBehaviour, ITutorialCanvasManager
{
    public Text Title_1;
    public Text Sentence_1;
    public Button ButtonForward;
    public Button ButtonBackward;
    public Text Title_2;
    public Text Sentence_2;
    //public Button ButtonForward_2;
    //public Button ButtonBackward_2;
    public Text Title_3;
    public Text Sentence_3;
    //public Button ButtonForward_3;
    //public Button ButtonBackward_3;
    private bool isScene1;
    private bool isScene2;
    private bool isScene3;

    public GameObject singleEnemy;

    void Start()
    {
        isScene1 = true;
        isScene2 = false;
        isScene3 = false;
        Title_1 = GameObject.Find("TitleLabel_1").GetComponent<Text>();
        Sentence_1 = GameObject.Find("Sentence_1").GetComponent<Text>();
        Title_2 = GameObject.Find("TitleLabel_2").GetComponent<Text>();
        Sentence_2 = GameObject.Find("Sentence_2").GetComponent<Text>();
        Title_3 = GameObject.Find("TitleLabel_3").GetComponent<Text>();
        Sentence_3 = GameObject.Find("Sentence_3").GetComponent<Text>();
        ButtonForward = GameObject.Find("ButtonForward").GetComponent<Button>();
        ButtonBackward = GameObject.Find("ButtonBackward").GetComponent<Button>();

    }

    public void ButtonForwardClicked()
    {
        if (isScene3)
        {
            //devi tornare al menu principale
            SceneManager.LoadScene("Menu");
        }
        if (isScene2)
        {
            //metto a false tutti i componenti della schermata precedente
            Title_2.enabled = false;
            Sentence_2.enabled = false;
            //metto a true i componenti attuali
            Title_3.enabled = true;
            Sentence_3.enabled = true;

            Instantiate(singleEnemy, new Vector3(0, 1.5f, 0), Quaternion.identity);

            isScene2 = false;
            isScene3 = true;
        }
        if (isScene1)
        {
            //metto a false tutti i componenti della schermata precedente
            Title_1.enabled = false;
            Sentence_1.enabled = false;
            //metto a true i componenti attuali
            Title_2.enabled = true;
            Sentence_2.enabled = true;

            isScene1 = false;
            isScene2 = true;
        }
    }

    public void ButtonBackwardClicked()
    {
        if (isScene1)
        {
            SceneManager.LoadScene("Menu");
        }
        if (isScene2)
        {
            //metto a true i componenti attuali
            Title_1.enabled = true;
            Sentence_1.enabled = true;
            //metto a false tutti i componenti della schermata precedente
            Title_2.enabled = false;
            Sentence_2.enabled = false;

            isScene2 = false;
            isScene1 = true;
        }
        if (isScene3)
        {
            //metto a true i componenti attuali
            Title_2.enabled = true;
            Sentence_2.enabled = true;
            //metto a false tutti i componenti della schermata precedente
            Title_3.enabled = false;
            Sentence_3.enabled = false;

            isScene3 = false;
            isScene2 = true;
        }
    }
}
