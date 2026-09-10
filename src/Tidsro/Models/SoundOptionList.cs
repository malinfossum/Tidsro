namespace Tidsro.Models;

/// <summary>Which sounds a picker offers. One rule in one place — the timer picker, the alarm picker,
/// the edit dialog and Settings all read this, so they cannot drift the way four copied arrays did.</summary>
public static class SoundOptionList
{
    private static readonly SoundChoice[] BuiltIn =
    [
        SoundChoice.None, SoundChoice.SoftChime, SoundChoice.Marimba, SoundChoice.Bell,
        SoundChoice.PianoJingle, SoundChoice.ElectricPianoJingle, SoundChoice.BellJingle,
    ];

    /// <param name="hasCustom">Whether a custom .wav is actually installed. When it isn't, the entry
    /// is left out rather than offered dead.</param>
    /// <param name="current">The choice already in force. Kept in the list even with no file, because
    /// a ComboBox whose SelectedItem is missing from its ItemsSource renders blank — which would read
    /// as an alarm having lost its sound.</param>
    public static SoundChoice[] For(bool hasCustom, SoundChoice current = SoundChoice.None) =>
        hasCustom || current == SoundChoice.Custom
            ? [.. BuiltIn, SoundChoice.Custom]
            : BuiltIn;
}
