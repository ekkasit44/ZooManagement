using System;

namespace ZooManagement
{
    internal static class DataEvents
    {
        public static event Action? AnimalsChanged;

        public static void RaiseAnimalsChanged()
        {
            AnimalsChanged?.Invoke();
        }
    }
}
