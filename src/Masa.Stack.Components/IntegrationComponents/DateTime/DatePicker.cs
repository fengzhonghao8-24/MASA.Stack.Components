﻿namespace Masa.Stack.Components;
public partial class DatePicker : MDatePicker<DateOnly?>
{
    [CascadingParameter]
    public new I18n I18n { get; set; } = default!;

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
        ChildContent = builder =>
        {
            builder.OpenComponent<MRow>(0);
            builder.AddAttribute(1, "Dense", true);
            builder.AddAttribute(2, "Align", (StringEnum<AlignTypes>)AlignTypes.Center);
            builder.AddAttribute(3, "Style", "width: min-content; padding: 0 12px;");
            builder.AddAttribute(4, "ChildContent", (RenderFragment)delegate (RenderTreeBuilder builder2)
            {
                builder2.OpenComponent<MCol>(1);
                builder2.AddAttribute(2, "Cols", (StringNumber)12);
                builder2.AddAttribute(3, "Style", "display: flex");
                builder2.AddAttribute(4, "ChildContent", (RenderFragment)delegate (RenderTreeBuilder builder3)
                {
                    var hasToday = true;
                    var toDay = DateOnly.FromDateTime(DateTime.Now);
                    if (Max is not null && Min is not null) hasToday = (Min.Value <= toDay && toDay <= Max.Value);
                    else if (Max is not null) hasToday = toDay <= Max.Value;
                    else if (Min is not null) hasToday = toDay >= Min.Value;
                    if (hasToday)
                    {
                        builder3.OpenComponent<MButton>(0);
                        builder3.AddAttribute(1, "Text", true);
                        builder3.AddAttribute(2, "Color", "primary");
                        builder3.AddAttribute(3, "ChildContent", (RenderFragment)delegate (RenderTreeBuilder builder4)
                        {
                            builder4.AddContent(1, I18n.T("ToDay"));
                        });
                        builder3.AddAttribute(4, "OnClick", EventCallback.Factory.Create(this, ToDayAsync));
                        builder3.CloseComponent();
                    }
                    builder3.OpenComponent<MSpacer>(5);
                    builder3.CloseComponent();
                    builder3.OpenComponent<MButton>(6);
                    builder3.AddAttribute(7, "Text", true);
                    Console.WriteLine(Value.ToString());
                    builder3.AddAttribute(8, "ChildContent", (RenderFragment)delegate (RenderTreeBuilder builder5)
                    {
                        builder5.AddContent(1, I18n.T("Reset"));
                    });
                    builder3.AddAttribute(9, "OnClick", EventCallback.Factory.Create(this, ResetAsync));
                    builder3.CloseComponent();
                });
                builder2.CloseComponent();
            });
            builder.CloseComponent();
        };
    }

    private async Task ToDayAsync(MouseEventArgs args)
    {
        if (ValueChanged.HasDelegate) await ValueChanged.InvokeAsync(DateOnly.FromDateTime(DateTime.Now));
        else Value = DateOnly.FromDateTime(DateTime.Now);
        if (OnInput.HasDelegate) await OnInput.InvokeAsync();
    }

    private async Task ResetAsync(MouseEventArgs args)
    {
        if (ValueChanged.HasDelegate) await ValueChanged.InvokeAsync(null);
        else Value = null;
        if (OnInput.HasDelegate) await OnInput.InvokeAsync();
    }
}

