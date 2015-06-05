﻿using Newtonsoft.Json;

namespace MobileCRM.Shared.Models
{
    public class BaseModel
    {
      public BaseModel()
      {
        
      }

      [JsonProperty(PropertyName = "id")]
      public string Id { get; set; }

      [Microsoft.WindowsAzure.MobileServices.Version]
      public string Version { get; set; }
    }
}
