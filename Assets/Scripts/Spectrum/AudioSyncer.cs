using UnityEngine;

public class AudioSyncer : MonoBehaviour
{
    public virtual void OnBeat()
    {
        timer = 0;
        isBeat = true;
    }

    public virtual void OnUpdate()
    {
        // update audio value
        previousAudioValue = audioValue;
        audioValue = AudioSpectrum.spectrumValue;

        // if audio value went below the bias during this frame
        if (previousAudioValue > bias &&
            audioValue <= bias)
        {
            // if minimum beat interval is reached
            if (timer > timeStep)
                OnBeat();
        }

        // if audio value went above the bias during this frame
        if (previousAudioValue <= bias &&
            audioValue > bias)
        {
            // if minimum beat interval is reached
            if (timer > timeStep)
                OnBeat();
        }

        timer += Time.deltaTime;
    }

    private void Update()
    {
        OnUpdate();
    }

    public float bias;
    public float timeStep;
    public float timeToBeat;
    public float restSmoothTime;

    private float previousAudioValue;
    private float audioValue;
    private float timer;

    protected bool isBeat;
}