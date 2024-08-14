namespace Framework._Task_1.Helpers
{
    public class ConfigurationHelper
    {
        private readonly Dictionary<string, string> config;

        public ConfigurationHelper(string filePath)
        {
            config = [];
            foreach (var row in File.ReadAllLines(filePath))
            {
                var split = row.Split('=');
                config.Add(split[0], split[1]);
            }
        }

        public string GetValue(string key)
        {
            return config[key];
        }
    }

}
