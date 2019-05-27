using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerTest : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClickSFX;
    [SerializeField] private AudioClip music1;
    [SerializeField] private AudioClip music2;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            AudioManager.Instance.PlaySFX(buttonClickSFX);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            AudioManager.Instance.PlayMusic(music1);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            AudioManager.Instance.PlayMusic(music2);
        }

        if(Input.GetKeyDown(KeyCode.X)){
            AudioManager.Instance.PlayMusicWithFade(music1);
        }

        if(Input.GetKeyDown(KeyCode.Z)){
            AudioManager.Instance.PlayMusicWithFade(music2);
        }

        if(Input.GetKeyDown(KeyCode.C)){
            AudioManager.Instance.PlayMusicWithCrossFade(music1, 3.0f);
        }

        if(Input.GetKeyDown(KeyCode.S)){
            AudioManager.Instance.PlayMusicWithCrossFade(music2, 3.0f);
        }
        
    }
}
