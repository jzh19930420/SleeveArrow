using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using EventTrigger = Microsoft.Xaml.Behaviors.EventTrigger;
using TriggerBase = Microsoft.Xaml.Behaviors.TriggerBase;

namespace SleeveArrow.Mvvm;

public static class EventCommandExtension
{
    public static string GetAttach(DependencyObject obj)
    {
        return (string)obj.GetValue(AttachProperty);
    }

    public static void SetAttach(DependencyObject obj, string value)
    {
        obj.SetValue(AttachProperty, value);
    }

    public static readonly DependencyProperty AttachProperty =
        DependencyProperty.RegisterAttached("Attach", typeof(string), typeof(EventCommandExtension), new PropertyMetadata(null, OnAttachChanged));

    private static void OnAttachChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue == e.OldValue) return;

        var allTriggers = Interaction.GetTriggers(d);
        var trigger = BuildTrigger(d, e.NewValue as string);
        allTriggers.Add(trigger);
    }

    private static TriggerBase BuildTrigger(DependencyObject d, string triggerText)
    {
        var control = d as FrameworkElement;
        if (control is null) return null;
        var tts = triggerText.Split('=');
        if (tts.Length != 2)
        {
            return null;
        }
        var eventName = tts[0].Replace("[", string.Empty).Replace("]", string.Empty).Trim();
        var cmdNames = tts[1].Replace("[", string.Empty).Replace("]", string.Empty).Trim();

        var eventTrigger = new EventTrigger(eventName);
        var cmdAction = new InvokeCommandAction();

        var cmdBinding = new Binding();
        cmdBinding.Source = control.DataContext;
        if (cmdNames.Contains("("))
        {
            var cmd = cmdNames.Split("(");
            if (cmd.Length != 2)
            {
            }
        }
        else
        {
            cmdBinding.Path = new PropertyPath(cmdNames);
            BindingOperations.SetBinding(cmdAction, InvokeCommandAction.CommandProperty, cmdBinding);
        }

        eventTrigger.Actions.Add(cmdAction);

        return eventTrigger;
    }
}