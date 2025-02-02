﻿using Newtonsoft.Json;

namespace Consensus.Backend.Models
{
    public class UsersSavedHive
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        [JsonProperty("_from")]
        public string From { get; set; }
        
        [JsonProperty("_to")]
        public string To { get; set; }
        
        public SavedHiveOwnershipType OwnershipOwnershipType { get; set; }
    }
}