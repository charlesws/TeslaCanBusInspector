﻿using TeslaCanBusInspector.Common.ValueTypes;

// ReSharper disable UnusedMember.Global
namespace TeslaCanBusInspector.Common.Messages.ModelS
{
    public class RearTorqueMessage : IRearTorqueMessage
    {
        public CarType CarType => CarType.ModelS | CarType.ModelX;
        public ushort MessageTypeId => 0x154;
        public byte RequireBytes => 7;

        public NewtonMeter RearTorque { get; }
        public Percent WattPedal { get; }

        internal RearTorqueMessage()
        {
        }

        public RearTorqueMessage(byte[] payload)
        {
            payload.RequireBytes(RequireBytes);

            RearTorque = new NewtonMeter((payload[5] + ((payload[6] & 0x1F) << 8) - 512 * (payload[6] & 0x10)) * 0.25m);
            WattPedal = new Percent(payload[3] * 0.4m);
        }
    }

    public interface IRearTorqueMessage : ICanBusMessage
    {
        NewtonMeter RearTorque { get; }
        Percent WattPedal { get; }
    }
}