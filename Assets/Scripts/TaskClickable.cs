using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskClickable : MonoBehaviour
{
    public TaskID clickableCompletionID;

    public void Click() {
        Debug.Log("Button clicked: "+clickableCompletionID);
        TaskManagerScript.CompleteTask(clickableCompletionID);
    }
}
