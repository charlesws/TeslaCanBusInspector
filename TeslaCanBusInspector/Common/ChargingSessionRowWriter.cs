﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCanBusInspector.Common
{
    public class ChargingSessionRowWriter : IChargingSessionRowWriter
    {
        private static readonly Dictionary<string, Func<ChargingSessionRow, string>> Properties =
            new Dictionary<string, Func<ChargingSessionRow, string>>
            {
                { nameof(ChargingSessionRow.Timestamp), row => '"' + row.Timestamp.ToString("o") + '"' },
                { nameof(ChargingSessionRow.StateOfCharge), row => row.StateOfCharge?.Value.ToString("F1") },
                { nameof(ChargingSessionRow.BatteryVoltage), row => row.BatteryVoltage?.Value.ToString("F1") },
                { nameof(ChargingSessionRow.BatteryCurrent), row => row.BatteryCurrent?.Value.ToString("F1") }
            };

        public async Task WriteHeader(StreamWriter writer)
        {
            var sb = new StringBuilder();

            foreach (var property in Properties)
            {
                if (sb.Length > 0) sb.Append(',');
                sb.Append(property.Key);
            }

            await writer.WriteLineAsync(sb.ToString());
        }

        public async Task WriteLine(StreamWriter writer, ChargingSessionRow row)
        {
            var sb = new StringBuilder();

            foreach (var property in Properties)
            {
                if (sb.Length > 0) sb.Append(',');
                sb.Append(property.Value(row));
            }

            await writer.WriteLineAsync(sb.ToString());
        }
    }

    public interface IChargingSessionRowWriter
    {
        Task WriteHeader(StreamWriter writer);
        Task WriteLine(StreamWriter writer, ChargingSessionRow row);
    }
}