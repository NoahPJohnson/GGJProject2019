using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

   /* [FMODUnity.EventRef]
    public string BackgroundMusic;
    public float currentDistanceTo;
    public float currentDistanceFrom;
    public int randomVariable;
    FMOD.Studio.Bus MasterBus;
    FMOD.Studio.EventInstance musicEvent;
    FMOD.Studio.ParameterInstance Variation;
    FMOD.Studio.ParameterInstance DistanceToExit;
    FMOD.Studio.ParameterInstance DistanceFromHome;

    private void Start ()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
        musicEvent = FMODUnity.RuntimeManager.CreateInstance(BackgroundMusic);
        musicEvent.getParameter("Variation", out Variation);
        musicEvent.getParameter("Distance To Exit", out DistanceToExit);
        musicEvent.getParameter("DistanceFromHome", out DistanceFromHome);
        ResetMusicValues();
        currentDistanceFrom = 0;
        currentDistanceTo = 100;
        randomVariable = Random.Range (1, 160);
        Variation.setValue(randomVariable);
        musicEvent.start();

    }
	
	void Update ()
    {
        //get location from home, exit
        DistanceToExit.setValue(currentDistanceTo);
        DistanceFromHome.setValue(currentDistanceFrom);
	}

    public void ResetMusicValues()
    {
        Variation.setValue(0);
        DistanceToExit.setValue(100);
        DistanceFromHome.setValue(0);
    }

    public void StopMusic()
    {
        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicEvent.release();
    }*/
}
