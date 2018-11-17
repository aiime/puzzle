using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.Audio
{
    [AddComponentMenu("Puzzle/Audio/SFX Volume Slider")]
    public class SFXVolumeSliderBehaviour : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Slider slider;

        public void OnSliderValueChanged()
        {
            audioSource.volume = slider.value;
        }
    }
}

