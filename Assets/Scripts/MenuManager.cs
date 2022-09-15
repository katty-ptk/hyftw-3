using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private Toggle fullscreen_toggle, vsync_toggle;
    [SerializeField] private List<ResolutionItem> resolutionItems;
    [SerializeField] private TextMeshProUGUI resolution_text;

    [Header("Audio")]
    [SerializeField] private AudioSource music_source, sound_effects_source;
    [SerializeField] private Slider music_slider, sound_effects_slider, master_slider;

    private int selected_resolution_value;

    private void Start() {
        fullscreen_toggle.isOn = Screen.fullScreen;
        vsync_toggle.isOn = !(QualitySettings.vSyncCount == 0); 
    }

    public void PreviousResolution() {
        selected_resolution_value -= 1;
        if (selected_resolution_value < 0)
            selected_resolution_value = 0;
        UpdateResolutionTextValue();
    }

    public void NextResolution() {
        selected_resolution_value += 1;
        if (selected_resolution_value > resolutionItems.Count - 1)
            selected_resolution_value = resolutionItems.Count - 1;
        UpdateResolutionTextValue();
    }

    private void UpdateResolutionTextValue() {
        resolution_text.text 
            = resolutionItems[selected_resolution_value].horizontal.ToString()
            + " x "
            + resolutionItems[selected_resolution_value].vertical.ToString();
    }

    public void ChangeVolume( string type ) {
        switch ( type ) {
            case "music":
                music_source.volume = music_slider.value;
                break;

            case "sfx":
                sound_effects_source.volume = sound_effects_slider.value;
                break;

            case "master":
                music_source.volume = master_slider.value;
                music_slider.value = master_slider.value;
                sound_effects_slider.value = master_slider.value;
                sound_effects_slider.value = master_slider.value;
                break;
        }
    }

    public void Save() {
        QualitySettings.vSyncCount = vsync_toggle.isOn ? 1 : 0;

        Screen.SetResolution(
            resolutionItems[selected_resolution_value].horizontal,
            resolutionItems[selected_resolution_value].vertical,
            fullscreen_toggle.isOn
        );
    }
}


// resolution items class
[System.Serializable] // this makes it show in the editor
public class ResolutionItem {
    public int horizontal, vertical;
}