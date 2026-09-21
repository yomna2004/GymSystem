using GymSystem_Business;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GymSystem.Global_Classes
{
    internal class clsGlobal
    {
        public static clsUser CurrentUser;

        private static readonly string _registryKeyPath = @"SOFTWARE\GymSystem";

        private static string EncodeToBase64(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }

        private static string DecodeFromBase64(string base64Text)
        {
            if (string.IsNullOrEmpty(base64Text)) return "";
            byte[] bytes = Convert.FromBase64String(base64Text);
            return Encoding.UTF8.GetString(bytes);
        }

        public static bool RememberUsernameAndPassword(string username, string password)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(_registryKeyPath))
                {
                    if (key == null) return false;

                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {
                        key.SetValue("Username", username, RegistryValueKind.String);
                        key.SetValue("Password", EncodeToBase64(password), RegistryValueKind.String);
                    }
                    else
                    {
                        key.DeleteValue("Username", false);
                        key.DeleteValue("Password", false);
                    }
                }
                return true;
            }
            catch(SqlException ex)
            {
                LoggerHelper.LogError("clsGlobal.RememberUsernameAndPassword", ex);
                return false;
            }
        }

        public static bool GetStoredCredential(ref string username, ref string password)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(_registryKeyPath))
                {
                    if (key != null)
                    {
                        string storedUser = key.GetValue("Username") as string;
                        string storedPass = key.GetValue("Password") as string;

                        if (!string.IsNullOrEmpty(storedUser) && !string.IsNullOrEmpty(storedPass))
                        {
                            username = storedUser;
                            password = DecodeFromBase64(storedPass);
                            return true;
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                LoggerHelper.LogError("clsGlobal.RememberUsernameAndPassword", ex);
            }

            return false;
        }
    }
}

