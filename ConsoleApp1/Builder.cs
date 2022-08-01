using System;

namespace DesignPatternsSamples;

public interface INotifcationBuilder
{
    public Notification Build();
    public NotifcationBuilder AddDate(DateOnly date);
    public NotifcationBuilder AddTime(TimeOnly time);
    public NotifcationBuilder AddTopic(String topic);
    public NotifcationBuilder AddMessage(String topic);
    public NotifcationBuilder SetChannel(NotifcicationChannel channel);
}

public enum NotifcicationChannel
{
    SMS = 1,
    Email = 2
}

public class Notification
{
    public Notification() { }

    public DateOnly Date { get; set; } = default!;
    public TimeOnly Time { get; set; } = default!;
    public string Topic { get; set; } = default!;
    public string Message { get; set; } = default!;
    public NotifcicationChannel Channel { get; set; } = default!;
}


public class NotifcationBuilder : INotifcationBuilder
{
    public NotifcationBuilder() 
    {
        New();
    }

    private Notification _notification;

    private void New()
    {
        _notification = new Notification();
        _notification.Channel = NotifcicationChannel.Email;
    }

    public Notification Build()
    {
        return _notification;
    }

    public NotifcationBuilder AddDate(DateOnly date)
    {
        _notification.Date = date;
        return this;
    }

    public NotifcationBuilder AddTime(TimeOnly time)
    {
        _notification.Time = time;
        return this;
    }

    public NotifcationBuilder AddTopic(string topic)
    {
        _notification.Topic = topic;
        return this;
    }

    public NotifcationBuilder AddMessage(string message)
    {
        _notification.Message = message;
        return this;
    }

    public NotifcationBuilder SetChannel(NotifcicationChannel channel)
    {
        _notification.Channel = channel;
        return this;
    }
}