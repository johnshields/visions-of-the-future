using UnityEngine;

/*
 * AudioMenu
 * Script to control in MainMenu - Audio Options (buttons).
 */
public class AudioMenu : MonoBehaviour
{
    public static bool mute;

    public void Mute()
    {
        mute = true;
        AudioListener.volume = 0f;
    }

    public void UnMute()
    {
        mute = false;
        AudioListener.volume = 1f;
    }
}