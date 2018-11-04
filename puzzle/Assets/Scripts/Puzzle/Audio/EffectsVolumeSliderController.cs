using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.Audio
{
    [AddComponentMenu("Puzzle/Audio/Effects Volume Slider Controller")]
    public class EffectsVolumeSliderController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Slider slider;

        public void OnSliderValueChanged()
        {
            audioSource.volume = slider.value;
        }
    }
}

