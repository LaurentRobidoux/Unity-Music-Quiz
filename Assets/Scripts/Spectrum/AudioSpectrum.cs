using UnityEngine;

//https://github.com/coderDarren/RenaissanceCoders_UnityScripting/tree/master/UnityScripting/Assets/Tutorials/MusicSyncVisualizer
public class AudioSpectrum : MonoBehaviour
{
    private float[] spectrumData = new float[128];
    public float normalizeValue = 100;

    public static float spectrumValue;

    private void Update()
    {
        AudioListener.GetSpectrumData(spectrumData, 0, FFTWindow.Hamming);
        if (spectrumData != null && spectrumData.Length > 0)
        {
            spectrumValue = spectrumData[0] * normalizeValue;
        }
    }
}