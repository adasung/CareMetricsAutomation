using System;

namespace FrameworkCore.Models
{
    public class VitalsPayload
    {
        public string PatientId { get; set; } = string.Empty;
        public int HeartRate { get; set; }
        public int SpO2 { get; set; }
        public int RespiratoryRate { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}