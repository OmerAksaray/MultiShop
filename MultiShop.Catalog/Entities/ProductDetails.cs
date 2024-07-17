﻿using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class ProductDetails
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string ProductDetailID{ get; set; }

        public string ProductDescription { get; set; }

        public string ProductionInfo { get; set; }

        public string ProductId { get; set; }

        [BsonIgnore]

        public Product Product { get; set; }
    }
}
