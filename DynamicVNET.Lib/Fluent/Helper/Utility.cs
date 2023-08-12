using System;
using System.Diagnostics;

namespace DynamicVNET.Lib
{
    internal static class Utility
    {
        /// <summary>
        /// Wrapper to all marking operations.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="markName">Name of the mark.</param>
        /// <exception cref="Exception">Occurred error in {markName}!</exception>
        public static void Track<T>(Action body, string markName)
        {
            Trace.WriteLine($"{typeof(T)} Entry {nameof(Track)} -> {markName}");

            try
            {
                body();
            }
            catch (Exception exp)
            {
                Trace.WriteLine($"{exp.Message} || {exp.StackTrace} || {exp.InnerException?.Message}");
                throw new Exception($"{typeof(T)} Occurred error in {markName}!", exp);
            }
        }

        /// <summary>
        /// Wrapper to all marking operations.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="markName">Name of the mark.</param>
        /// <exception cref="Exception">Occurred error in {markName}!</exception>
        public static void Track(Action body, string markName)
        {
            Trace.WriteLine($"Entry {nameof(Track)} -> {markName}");

            try
            {
                body();
            }
            catch (Exception exp)
            {
                Trace.WriteLine($"{exp.Message} || {exp.StackTrace} || {exp.InnerException?.Message}");
                throw new Exception($"Occurred error in {markName}!", exp);
            }
        }
    }
}
