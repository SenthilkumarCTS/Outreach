namespace MemberOutReachSystem.API
{
    public class ConfigurationSetting
    {
        public string ServiceName { get; set; }
        public string ServiceHost { get; set; }
        public int ServicePort { get; set; }
        public string ConsulAddress { get; set; }
        public DatabaseSettings DatabaseSettings { get; set; }
    }
}
