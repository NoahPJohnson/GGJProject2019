using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform home;
    [SerializeField] Transform destination;

    [FMODUnity.EventRef]
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

        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Debug.Log("Play music");
    }
	
	void Update ()
    {
        //FMODUnity.RuntimeManager.AttachInstanceToGameObject(musicEvent, transform,GetComponent<Rigidbody>());
        //get location from home, exit
        currentDistanceTo = Vector2.Distance(player.position, destination.position);
        currentDistanceFrom = Vector2.Distance(player.position, home.position);
        DistanceToExit.setValue(currentDistanceTo);
        DistanceFromHome.setValue(currentDistanceFrom);
	}

    public void ResetMusicValues()
    {
        Variation.setValue(0);
        DistanceToExit.setValue(100);
        DistanceFromHome.setValue(0);
    }

    public void InitializeMusic()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
        musicEvent = FMODUnity.RuntimeManager.CreateInstance(BackgroundMusic);
        musicEvent.getParameter("Variation", out Variation);
        musicEvent.getParameter("Distance To Exit", out DistanceToExit);
        musicEvent.getParameter("DistanceFromHome", out DistanceFromHome);
        ResetMusicValues();
        currentDistanceFrom = 0;
        currentDistanceTo = 100;
        randomVariable = Random.Range(1, 160);
        Variation.setValue(randomVariable);
        musicEvent.start();

        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void StopMusic()
    {
        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicEvent.release();
        
    }

    public void SwapHomes()
    {
        Transform temp = home;
        home = destination;
        destination = temp;
        InitializeMusic();
    }
}
