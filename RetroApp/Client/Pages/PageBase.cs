using Microsoft.AspNetCore.Components;
using RetroApp.Client.Shared;
using Microsoft.JSInterop;

namespace RetroApp.Client.Pages;

public class PageBase : ComponentBase
{
    [CascadingParameter]
    protected StateProvider StateProvider { get; set; } = new StateProvider();
#pragma warning disable CS8618
    [Inject]
    protected IJSRuntime JS { get; set; }
    [Inject]
    protected NavigationManager NavManager { get; set; }
}
