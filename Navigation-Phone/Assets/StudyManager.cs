using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HCIKonstanz.Colibri.Sync;

public class StudyManager : SyncedBehaviour<StudyManager>
{
    public override string Channel => "aroundthesmartphone";
 
    [Sync]
    public int studySet;

    [Sync]
    public int participantID;

    [Sync]
    public int startingCondition;

    [Sync]
    public bool rightHanded;

    [Sync]
    public int iconCount;
    
    [Sync]
    public bool showScreen;
    
    [Sync]
    public int SetIndex;
}
