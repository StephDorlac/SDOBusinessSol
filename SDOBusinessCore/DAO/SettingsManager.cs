using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SDOBusinessCore.DAO
{
    public sealed class SettingsManager
    {
        /// <summary>
        /// Reads the setting.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static String ReadSetting(string key)
        {
            String result = String.Empty;
            try
            {
                if (String.IsNullOrEmpty(key))
                    throw new ArgumentNullException("key", "key cannot be null or empty in ReadSetting!");

                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? $"{key} Not Found";                
            }
            catch (Exception ex)
            {
                //TODO : log !
                result = ex.ToString();
            }
            return result;
        }
    }
}
