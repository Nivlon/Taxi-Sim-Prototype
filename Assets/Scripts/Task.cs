using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Task
{
    public TaskID taskReq;
    public string taskText;

    public Task(TaskID _taskReq,string _taskText) {
        this.taskReq = _taskReq;
        this.taskText = _taskText;
    }
}
