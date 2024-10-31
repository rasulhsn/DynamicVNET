using System;
using System.Diagnostics;

namespace DynamicVNET.Lib.Helper
{
    internal static class Utility
    {
        /// <summary>
        /// Wrapper to all marking operations.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="markName">Name of the mark.</param>
        /// <exception cref="Exception">Occurred error in {markName}!</exception>
        public static void TrackTrace<T>(Action body, string markName)
        {
            Trace.WriteLine($"{typeof(T)} Entry {nameof(TrackTrace)} -> {markName}");

            try
            {
                body();
            }
            catch (Exception exp)
            {
                Trace.WriteLine($"{exp.Message} || {exp.StackTrace} || {exp.InnerException?.Message}");
                throw;
            }
        }

        /// <summary>
        /// Wrapper to all marking operations.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="markName">Name of the mark.</param>
        /// <exception cref="Exception">Occurred error in {markName}!</exception>
        public static void TrackTrace(Action body, string markName)
        {
            Trace.WriteLine($"Entry {nameof(TrackTrace)} -> {markName}");

            try
            {
                body();
            }
            catch (Exception exp)
            {
                Trace.WriteLine($"{exp.Message} || {exp.StackTrace} || {exp.InnerException?.Message}");
                throw;
            }
        }
    }
}
