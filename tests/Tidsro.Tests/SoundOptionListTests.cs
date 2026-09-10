using Tidsro.Models;

namespace Tidsro.Tests;

/// <summary>One rule, one place: which sounds a picker offers. Every picker in the app reads this,
/// so the three view-models can't drift apart the way three copied arrays would.</summary>
public class SoundOptionListTests
{
    [Fact]
    public void Without_a_custom_sound_the_picker_offers_the_built_ins_only()
    {
        var options = SoundOptionList.For(hasCustom: false);

        Assert.Equal(
            new[] { SoundChoice.None, SoundChoice.SoftChime, SoundChoice.Marimba, SoundChoice.Bell,
                    SoundChoice.PianoJingle, SoundChoice.ElectricPianoJingle, SoundChoice.BellJingle },
            options);
        Assert.DoesNotContain(SoundChoice.Custom, options);   // nothing dead in the list
    }

    [Fact]
    public void With_a_custom_sound_installed_it_is_offered_last()
    {
        var options = SoundOptionList.For(hasCustom: true);

        Assert.Equal(SoundChoice.Custom, options[^1]);
        Assert.Equal(8, options.Length);
    }

    // Otherwise the ComboBox holds a SelectedItem that is not in its ItemsSource and renders blank —
    // an alarm would look like it had lost its sound because the .wav was removed.
    [Fact]
    public void An_alarm_already_set_to_the_custom_sound_keeps_the_entry_even_with_no_file()
    {
        var options = SoundOptionList.For(hasCustom: false, current: SoundChoice.Custom);

        Assert.Contains(SoundChoice.Custom, options);
    }

    [Fact]
    public void A_built_in_current_choice_does_not_conjure_the_custom_entry()
    {
        var options = SoundOptionList.For(hasCustom: false, current: SoundChoice.Bell);

        Assert.DoesNotContain(SoundChoice.Custom, options);
    }
}
