namespace Tidsro.Models;

/// <summary>Which sound an alarm or timer makes. Persisted as its integer value, so new members are
/// appended and never inserted — see <c>SoundChoiceTests</c>. <see cref="Custom"/> is the single
/// user-supplied .wav slot; the file itself is owned by <c>CustomSoundStore</c>.</summary>
public enum SoundChoice { None, SoftChime, Marimba, Bell, PianoJingle, ElectricPianoJingle, BellJingle, Custom }
