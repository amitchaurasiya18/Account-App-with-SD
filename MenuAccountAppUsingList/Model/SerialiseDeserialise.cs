using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace MenuAccountAppUsingList.Model
{
    internal class SerialiseDeserialise
    {
        public static void Serialize(List<Account> accounts)
        {
            File.WriteAllText("AccountDatabaseWithList.json", JsonConvert.SerializeObject(accounts, Newtonsoft.Json.Formatting.Indented));
        }

        public static List<Account> Deserialize()
        {
            List<Account> accounts = new List<Account>();
            string fileName = "AccountDatabaseWithList.json";
            if (File.Exists(fileName))
            {
                string fileData = File.ReadAllText(fileName);
                var deserialsedAccount = JsonConvert.DeserializeObject<Account[]>(fileData);

                if (deserialsedAccount != null)
                {
                    for (int i = 0; i < deserialsedAccount.Length; i++)
                    {
                        accounts.Add(deserialsedAccount[i]);
                    }
                }
            }
            else
            {
                File.WriteAllText("AccountDatabase.json", JsonConvert.SerializeObject(accounts));
            }
            return accounts;
        }
    }
}

