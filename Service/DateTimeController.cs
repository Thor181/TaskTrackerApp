

namespace TaskTrackerApp.Service
{
    internal class DateTimeController 
    {
        internal static string CalculateDifference(DateTime dateRegister)
        {
            var now = DateTime.Now;
            short days = (short)(now.Subtract(dateRegister).TotalHours / 24);
            byte hours = (byte)(now.Subtract(dateRegister).TotalHours % 24);
            return $"{days}d {hours}h";
        }
    }
}
