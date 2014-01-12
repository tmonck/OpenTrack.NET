using System;
using System.Configuration;

namespace OpenTrack.Tests
{
    public static class Settings
    {
        public static readonly String ServerName = ConfigurationManager.AppSettings["servername"];
    }
}