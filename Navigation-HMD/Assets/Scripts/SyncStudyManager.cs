using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HCIKonstanz.Colibri.Sync;

public class SyncStudyManager : SyncedBehaviourManager<StudyManager>
{
    public override string Channel => "aroundthesmartphone";
}
