using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeddingMApp.Models
{
    public class AppModelClass
    {
        public ObjectId Id { get; set; }
        public string CLIENTNO { get; set; }
        public string NAME { get; set; }
        public string CONTACT { get; set; }
        public string DATE { get; set; }
        public string TIME { get; set; }
        public string SUBJECT { get; set; }
        public string DESCRIPTION { get; set; }
    }
}
