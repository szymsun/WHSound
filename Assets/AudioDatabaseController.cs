using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[System.Serializable]
public struct AudioData
{
    public string key;
    public AudioClip clip;
}


public class AudioDatabaseController : MonoBehaviour
{
    [SerializeField]
    public Dictionary<string, AudioClip> audioDictionary;  


    // Workarround shit to make memory access better? (i hope)
    [Tooltip("IMPORTANT: you can't assign audioClips in runtime")]
    public AudioData[] audioDataArray;



    public GameObject errorMessageBox;
    public TMP_Text errorMessageText;
    
    
    private AudioSource _source;

    void Start()
    {
        _source = GetComponent<AudioSource>();
    }


    void AssignDataToDictionary()
    {

    }


    public void PlayAudio(string AudioKey)
    {
       AudioClip CClip;
        
        if(audioDictionary.TryGetValue(AudioKey, out CClip))
        {
            _source.clip = CClip;
            _source.Play();
        }
        else { errorMessageText.text = "Error: Key " + AudioKey + " does not exist. SHIT"; errorMessageBox.SetActive(true); }
    }
}
