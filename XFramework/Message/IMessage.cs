﻿namespace XFramework.Message
{
    public interface IMessage
    {
        string Id { get; set; }
        string Key { get; set; }
        string[] Tags { get; set; }
    }
}