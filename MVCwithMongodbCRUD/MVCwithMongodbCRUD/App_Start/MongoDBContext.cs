﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
namespace MVCwithMongodbCRUD.App_Start
{
	public class MongoDBContext
	{
		MongoClient client;
		public IMongoDatabase database;
		public MongoDBContext()
		{
			var mongoClient = new MongoClient(ConfigurationManager.AppSettings["MongoDBHost"]);
			database = mongoClient.GetDatabase(ConfigurationManager.AppSettings["MongoDBName"]);
		}
	}
}