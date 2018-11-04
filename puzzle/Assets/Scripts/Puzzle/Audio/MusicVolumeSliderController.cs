using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.Audio
{
    [AddComponentMenu("Puzzle/Audio/Music Volume Slider Controller")]
    public class MusicVolumeSliderController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private Slider slider;

        public void OnSliderValueChanged()
        {
            audioSource.volume = slider.value;
        }
    }
}
