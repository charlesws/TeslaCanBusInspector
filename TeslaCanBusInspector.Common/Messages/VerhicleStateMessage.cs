﻿// ReSharper disable UnusedMember.Global
namespace TeslaCanBusInspector.Common.Messages
{
    public class VerhicleStateMessage : ICanBusMessage
    {
        public const ushort TypeId = 0x116;
        public ushort MessageTypeId => TypeId;

        internal VerhicleStateMessage()
        {
        }

        public VerhicleStateMessage(byte[] payload)
        {
            // TODO: add code here
        }
    }
}