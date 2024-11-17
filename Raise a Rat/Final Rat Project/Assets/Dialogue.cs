using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    public SpriteRenderer bg;
    public Sprite bg2;
    public Sprite bg3;
    public CanvasGroup uitrans;
    public CanvasGroup namebox; //made the input box transparent

    // Start is called before the first frame update
    void Start()
    {
        CanvasGroup uitrans = new CanvasGroup();
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            
            
            if (index == 0) 
            {
                Debug.Log("Start");
            }
           
            else if (index == 4)

            {
                Debug.Log("sentence 4");
                bg.sprite = bg2;
                uitrans.alpha = 0;

            }

            else if (index == 7)

            {
                bg.sprite = bg3;
                uitrans.alpha = 1;

            }
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
   

}