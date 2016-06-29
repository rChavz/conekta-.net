﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace conekta
{

	public class Resource : ConektaObject, ICloneable
	{
		Requestor requestor = new Requestor();

		public Resource () {}

		public string request(string method, string resource_uri, string data)
		{
			return requestor.request(method, resource_uri, data);
		}

		public string find(String resource_uri, String id)
		{
			return requestor.request("GET", resource_uri + "/" + id);
		}

		public string where(String resource_uri, String data)
		{
			Dictionary<string, string> obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);

			string list_params = "?";

			foreach (KeyValuePair<string, string> item in obj)
			{
				list_params += item.Key + "=" + item.Value + "&";
			}

			return requestor.request("GET", resource_uri + list_params.Substring(0, list_params.Length - 1));
		}

		public string create(String resource_uri, String data)
		{
			return requestor.request("POST", resource_uri, data);
		}

		public string update(String resource_uri, String data)
		{
			return requestor.request ("PUT", resource_uri, data);
		}

		public string delete(String resource_uri)
		{
			return requestor.request ("DELETE", resource_uri);
		}

	}

}