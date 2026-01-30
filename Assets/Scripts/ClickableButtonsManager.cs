using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ClickableButtonsManager : MonoBehaviour
{
    [SerializeField]
    private bool mustClickInOrder = false;
    [SerializeField]
    private bool[] clickedButtons;

    [SerializeField]
    private UnityEvent onAllButtonsClicked;

    [SerializeField]
    private AudioClip validClickAudio;
    [SerializeField]
    private AudioClip invalidClickAudio;
    [SerializeField]
    private AudioClip clickedAllAudio;
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private bool didFinish = false;
    private int numOfButtons =0;

    public void Start()
    {
        numOfButtons = GetComponentsInChildren<ClickableButton>().Count();
        clickedButtons = new bool[numOfButtons];

        didFinish = false;
    }

    public void ClickButton(uint buttonNumber)
    {
        if (didFinish)
        {
            return;
        }

        if (buttonNumber >= clickedButtons.Length)
        {
            PlayAudioClip(invalidClickAudio);
        }
        if (mustClickInOrder)
        {
            // Did click all previous buttons?
            for (int i = 0; i < buttonNumber; i++)
            {
                if (!clickedButtons[i])
                {
                    ResetButtons();
                    PlayAudioClip(invalidClickAudio);
                    return;
                }
            }
            // Did already click this button?
            if (clickedButtons[buttonNumber])
            {
                ResetButtons();
                PlayAudioClip(invalidClickAudio);
                return;
            }
            
            // Clicked correct button in order!
            clickedButtons[buttonNumber] = true;
            PlayAudioClip(validClickAudio);
        }
        else
        {
            // Did not click on it before?
            if (!clickedButtons[buttonNumber])
            {
                clickedButtons[buttonNumber] = true;
                PlayAudioClip(validClickAudio);
            }
        }

        if (clickedButtons.All(clicked => clicked))
        {
            PlayAudioClip(clickedAllAudio);
            onAllButtonsClicked.Invoke();
            didFinish = true;
        }
    }

    private void ResetButtons()
    {
        for (int i = 0; i < clickedButtons.Length; i++)
        {
            clickedButtons[i] = false;
        }
        didFinish = false;
    }

    private void PlayAudioClip(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    public int GetCurrButtonIndex()
    {
        for (int i = 0; i < numOfButtons; i++)
        {
            if(!clickedButtons[i])
            {
                return i;
            }
        }

        return numOfButtons-1;
    }
}
