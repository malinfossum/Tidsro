using Tidsro.Models;

namespace Tidsro.Tests;

public class SoundChoiceTests
{
    // SoundChoice persists as its integer value in every saved alarm, timer and settings file.
    // Custom was appended for that reason: inserting it anywhere else would silently re-point
    // every alarm in an existing data.json at a different sound.
    [Theory]
    [InlineData(SoundChoice.None, 0)]
    [InlineData(SoundChoice.SoftChime, 1)]
    [InlineData(SoundChoice.Marimba, 2)]
    [InlineData(SoundChoice.Bell, 3)]
    [InlineData(SoundChoice.PianoJingle, 4)]
    [InlineData(SoundChoice.ElectricPianoJingle, 5)]
    [InlineData(SoundChoice.BellJingle, 6)]
    [InlineData(SoundChoice.Custom, 7)]
    public void Each_choice_keeps_the_number_it_is_saved_as(SoundChoice choice, int expected)
        => Assert.Equal(expected, (int)choice);
}
