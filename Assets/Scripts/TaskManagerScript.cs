using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TaskID {tempUp,tempDown,changeMusic,volumeUp,volumeDown,switchGear,petPlant};
public class TaskManagerScript : MonoBehaviour
{
    public static TaskManagerScript instance;
    public float taskAddTime = 0f;
    private float taskAddTimer = 0f;
    public List<Task> taskPrefabList = new List<Task>();
    public List<Task> taskList = new List<Task>();
    public Text listText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        taskPrefabList.Add(new Task(TaskID.volumeUp,"Increase Volume"));
        taskPrefabList.Add(new Task(TaskID.volumeDown,"Decrease Volume"));
        taskPrefabList.Add(new Task(TaskID.tempUp,"Turn up the heat"));
        taskPrefabList.Add(new Task(TaskID.tempDown,"Turn down the heat"));
        taskPrefabList.Add(new Task(TaskID.changeMusic,"Switch music"));
        taskPrefabList.Add(new Task(TaskID.switchGear,"Switch Gear"));
        taskPrefabList.Add(new Task(TaskID.petPlant,"Pet Potty"));
        //Task text like "I am burning up in here!" or "switch that trash jazz"
    }

    // Update is called once per frame
    void Update()
    {
        taskAddTimer+=Time.deltaTime;
        if(taskAddTimer>taskAddTime) {
            TaskManagerScript.instance.taskList.Add(taskPrefabList[Random.Range(0,taskPrefabList.Count)]);
            taskAddTimer-=taskAddTime;
        }
        string todoText="TO-DO:\n";
        foreach(Task _task in TaskManagerScript.instance.taskList) {
            todoText = todoText + _task.taskText + "\n";
        }
        listText.text = todoText;
    }

    public static void CompleteTask(TaskID completionID) {
        Debug.Log("Task completed: "+completionID);
        for(int i=0;i<TaskManagerScript.instance.taskList.Count;i++) {
            if(TaskManagerScript.instance.taskList[i].taskReq==completionID) {
                Debug.Log("Completed task name: "+TaskManagerScript.instance.taskList[i].taskText);
                TaskManagerScript.instance.taskList.RemoveAt(i);
            }
        }
    }
}
