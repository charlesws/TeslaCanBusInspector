﻿using FluentAssertions;
using TeslaCanBusInspector.Common.Messages;
using TeslaCanBusInspector.Common.ValueTypes;
using Xunit;

namespace TeslaCanBusInspector.Tests.Messages
{
    public class BmsInfoMessageTests
    {
        private readonly byte[] _examplePayload = new byte[] { 0x4E, 0x22, 0xE9, 0x84 };

        [Fact]
        public void BmsMaxCharge()
        {
            // Act      
            var message = new BmsInfoMessage(_examplePayload);

            // Assert
            message.BmsMaxCharge.Should().Be(new KiloWatt(87.82));
        }
        
        [Fact]
        public void BmsMaxDischarge()
        {
            // Act      
            var message = new BmsInfoMessage(_examplePayload);

            // Assert
            message.BmsMaxDischarge.Should().Be(new KiloWatt(340.25));
        }
    }
}