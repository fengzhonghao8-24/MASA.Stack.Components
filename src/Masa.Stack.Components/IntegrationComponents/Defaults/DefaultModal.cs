﻿using Masa.Blazor.Presets;

namespace Masa.Stack.Components;

public class DefaultModal : PModal
{
    public override Task SetParametersAsync(ParameterView parameters)
    {
        HideActionsDivider = true;
        HideTitleDivider = true;
        HideCancelAction = true;
        Persistent = true;
        Width = 700;

        return base.SetParametersAsync(parameters);
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        Class ??= string.Empty;
        if (!Class.Contains("br-5"))
        {
            Class += " br-5";
        }

        HeaderClass ??= string.Empty;
        if (!HeaderClass.Contains("pa-6 font-20-bold default-text-emphasis-secondary"))
        {
            HeaderClass += " pa-6 font-20-bold default-text-emphasis-secondary";
        }

        ActionsClass ??= string.Empty;
        if (!ActionsClass.Contains("pa-6"))
        {
            ActionsClass += " pa-6";
        }
    }

    protected override ModalButtonProps GetDefaultSaveButtonProps()
    {
        var props = base.GetDefaultSaveButtonProps();
        props.Text = false;
        props.Rounded = true;
        props.Style = "width:100px";

        return props;
    }
}
