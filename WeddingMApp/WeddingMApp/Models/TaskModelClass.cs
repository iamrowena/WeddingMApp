using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeddingMApp.Models
{
    public class TaskModelClass //make sure na nakaPUBLIC
    {
        public ObjectId Id { get; set; }
        public string CLIENTNO { get; set; }
        public string NAME { get; set; }
        public string PACKAGE { get; set; }
        public string SERVICES { get; set; }
        public string WED_DETAILS { get; set; }
    }
}
