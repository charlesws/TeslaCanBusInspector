﻿using System;

namespace TeslaCanBusInspector.Models
{
    public class UnknownMessage : ICanBusMessage
    {
        public const ushort TypeId = 0x0;
        public ushort MessageTypeId => TypeId;

        public byte[] Payload { get; }

        internal UnknownMessage()
        {
        }

        public UnknownMessage(byte[] payload)
        {
            Payload = payload ?? throw new ArgumentNullException(nameof(payload));
        }
    }
}