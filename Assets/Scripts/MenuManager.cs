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

/*
    [Header("Sprites")]
    [SerializeField] private Sprite sound_off_sprite, sound_on_sprite;
*/

    [Header("Audio")]
    [SerializeField] private AudioSource music_source, sound_effects_source;
    [SerializeField] private Slider music_slider, sound_effects_slider, master_slider;

    [Header("Language")]
    [SerializeField] private GameObject language_button;
    [SerializeField] private Sprite EN, RO;

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

    public void Mute()
    {
        bool is_on = music_source.volume > 0;

        if (is_on) {    // mute
            music_source.volume = 0;
            music_slider.value = 0;
            sound_effects_source.volume = 0;
            sound_effects_slider.value = 0;
        } else
        {
            music_source.volume = 0.2f; 
            music_slider.value = 0.2f;
            sound_effects_source.volume = 0.2f;
            sound_effects_slider.value = 0.2f;
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

    public void Exit() {
        Application.Quit();
    }

    public void ToggleLanguage() {
        string current_language = language_button.name;

        switch( current_language) {
            case "EN":
                language_button.GetComponent<Image>().sprite = RO;
                language_button.name = "RO";
                // actually change language
                break;

            case "RO":
                language_button.GetComponent<Image>().sprite = EN;
                language_button.name = "EN";
                // actually change language
                break;
        }
    }
}


// resolution items class
[System.Serializable] // this makes it show in the editor
public class ResolutionItem {
    public int horizontal, vertical;
}