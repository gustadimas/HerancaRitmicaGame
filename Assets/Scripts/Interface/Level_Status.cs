using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Status : MonoBehaviour
{
    //[SerializeField] Fase_Management updateLvl;
    public string levelNm, desc;
    public int levelId;
    public bool completed = false;
    public int objectivesDone = 0;
    public bool isSelected = false;
    public string GMlink;

    void Start()
    {
        //updateLvl = GameObject.FindObjectOfType<Fase_Management>().GetComponent<Fase_Management>();
        //Fase_Management faseStatus = FindObjectOfType<Fase_Management>();
        
        //if (faseStatus.faseInfo.Count > levelId)
        //{
        //    this.completed = faseStatus.faseInfo[levelId - 1].completou;
        //    this.objectivesDone = faseStatus.faseInfo[levelId - 1].objetivos;
        //}
    }
}
