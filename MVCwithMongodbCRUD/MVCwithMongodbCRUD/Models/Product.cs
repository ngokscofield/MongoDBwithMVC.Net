using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MVCwithMongodbCRUD.Models
{
	//db.createUser({
	//	user: "reportsUser",
	//	pwd:"12345678",
	//	roles:[{role:"readWrite", db:"mydb"}]
	//})
	public class Product
	{
		private ObjectId _id;
		private string _productName;
		private string _description;
		private string _quantity;

		[BsonId]
		public ObjectId Id { get => _id; set => _id = value; }
		[BsonElement("ProductName")]
		public string ProductName { get => _productName; set => _productName = value; }
		[BsonElement("ProductDescription")]
		public string Description { get => _description; set => _description = value; }
		[BsonElement("Quantity")]
		public string Quantity { get => _quantity; set => _quantity = value; }
	}
}