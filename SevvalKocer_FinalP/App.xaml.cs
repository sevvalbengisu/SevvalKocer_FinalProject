using SevvalKocer_FinalP.Data;
using SevvalKocer_FinalP.Services;

namespace SevvalKocer_FinalP;

public partial class App : Application
{
    private readonly SeedService _seedService;

    public App(SeedService seedService)
    {
        InitializeComponent();
        _seedService = seedService;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        _ = _seedService.EnsureSeededAsync();

        return new Window(new AppShell());
    }
}