using System;

namespace RouterManagement.Services
{
    public class StatusService
    {
        public event Action<string, string> OnStatusMessageChanged;
        public bool IsServiceDown { get; set; } = false;

        public void UpdateStatusMessage(string message, string statusColor = "bg-blue-500")
        {
            OnStatusMessageChanged?.Invoke(message, statusColor);
        }
    }
}
