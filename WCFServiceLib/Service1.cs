using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;

namespace WCFServiceLib
{
    public class Service1 : IService1
    {
        public string GetData(string json)
        {
            User user = ReadToObject(json);
            if (FindUser(user))
                user.Exists = true;
            else
                user.Exists = false;
            return WriteFromObject(user);
        }
        public static bool FindUser(User user)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path += @"\users.csv";
            Debug.WriteLine(path);
            string[] users = File.ReadAllLines(path);
            foreach (var item in users)
                if (user.Login + " " + user.Pass == item)
                    return true;
            return false;
        }
        public static string WriteFromObject(User user)
        {
            var ms = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(User));
            ser.WriteObject(ms, user);
            byte[] json = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(json, 0, json.Length);
        }
        public static User ReadToObject(string json)
        {
            var deserializedUser = new User();
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var ser = new DataContractJsonSerializer(deserializedUser.GetType());
            deserializedUser = ser.ReadObject(ms) as User;
            ms.Close();
            return deserializedUser;
        }
    }
}
