using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace Your_Kcal_Day.Class
{
    class ProfileData
    {
        public const String profileFile = "profile.json";

        private JObject data;

        public ProfileData()
        {
            this.load();
        }

        public void set(String key, String value)
        {
            this.data[key] = value;
        }

        public String get(String key)
        {
            return this.data[key].ToString();
        }

        public Boolean isSet()
        {
            return (this.data.ContainsKey("wzrost") && this.data.ContainsKey("waga"));
        }


        private Boolean load()
        {
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + ProfileData.profileFile))
                try
                {
                    this.data = JObject.Parse(System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + ProfileData.profileFile));
                }
                catch
                {
                    this.data = JObject.Parse("{}");
                }
               
            else
                this.data = JObject.Parse("{}");

            return true;
        }

        public Boolean save()
        {
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + ProfileData.profileFile, this.data.ToString());
            return true;
        }


        public Boolean SaveEats(String Date, Array Eeats)
        {
            this.data[Date] = JArray.FromObject(Eeats);
            this.save();
            return true;
        }


        public Array LoadEats(String Date)
        {
            if (this.data.ContainsKey(Date))
                return this.data[Date].ToArray();
            else
            {
                var arr = new List<Object>();
                return arr.ToArray();
            }
                
        }
    }


}
