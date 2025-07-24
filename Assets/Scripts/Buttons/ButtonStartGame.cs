using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartGame : MonoBehaviour
{
    public ParticleSystem myparticleSystem;


    public void OnClick()
    {
        myparticleSystem.Play();
    }
}
