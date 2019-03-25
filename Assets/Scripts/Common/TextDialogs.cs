using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDialogs : MonoBehaviour
{
    [SerializeField]
    string[] dialogs;
    [SerializeField]
    float textSpeed = .2f;
    [SerializeField]
    float textExitDelay = 1.0f;

    StringBuilder dialogToPrint;
    string dialog;
    bool isRunning;
    bool completeText;
    int counter = 0;

    TextMeshProUGUI textMesh;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        dialogToPrint = new StringBuilder(50);
    }

    public void ShowDialog(int index, bool instant)
    {
        // Out of index check
        if (index > dialogs.Length)
            return;        

        // Complete text if current is active and is still running
        if (dialog == dialogs[index] && isRunning)
        {
            completeText = true;
            return;
        }

        // Change to new dialog and clear stringbuilder
        dialog = dialogs[index];
        dialogToPrint.Clear();

        // No animation wanted
        if (instant)
        {
            textMesh.text = dialog;
            return;
        }

        // If none is running start new coroutine else set counter to 0
        if (!isRunning)
        {
            StartCoroutine(AnimateDialog());
            isRunning = true;
        }
        else
            counter = 0;

    }

    IEnumerator AnimateDialog()
    {
        counter = 0;

        while(counter < dialog.Length)
        {
            if(completeText)
            {
                textMesh.text = dialog;
                completeText = false;
                isRunning = false;
                break;
            }

            dialogToPrint.Append(dialog[counter++]);
            
            textMesh.text = dialogToPrint.ToString();
            yield return new WaitForSeconds(textSpeed);
        }

        isRunning = false;
        Invoke("EmptyText", textExitDelay);
    }

    void EmptyText()
    {
        textMesh.text = "";
    }


}
