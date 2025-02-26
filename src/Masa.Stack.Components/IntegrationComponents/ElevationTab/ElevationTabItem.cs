﻿namespace Masa.Stack.Components;

public class ElevationTabItem : ComponentBase, IDisposable
{
    [CascadingParameter]
    private ElevationTab? Tab { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override void OnInitialized()
    {
        Tab?.AddTabItem(this);
        base.OnInitialized();
    }

    public void Dispose()
    {
        Tab?.RemoveTabItem(this);
    }
}
