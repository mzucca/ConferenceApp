﻿namespace ReHub.DbDataModel.Configuration
{
    public class DbConfiguration
    {
        public const string SectionName = nameof(DbConfiguration);
        public string ConnectionString { get; set; }
        public string EncryptionKey {  get; set; }
        public byte[] Salt {  get; set; }
    }
}