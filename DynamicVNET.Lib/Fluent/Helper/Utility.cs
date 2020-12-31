using System;
using System.Diagnostics;

namespace DynamicVNET.Lib
{
    internal static class Utility
    {
        /// <summary>
        /// Safe wrapper to all marking operations.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="markName">Name of the mark.</param>
        /// <exception cref="Exception">Occurred error in {markName}!</exception>
        public static void SafeMark<T>(Action body, string markName)
        {
            Debug.WriteLine($"Entry {nameof(SafeMark)} -> {markName}");

            try
            {
                body();
            }
            catch (Exception exp)
            {
                Debug.WriteLine($"{exp.Message} || {exp.StackTrace} || {exp.InnerException?.Message}");
                throw new Exception($"Occurred error in {markName}!", exp);
            }
        }
    }
}
