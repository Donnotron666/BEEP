using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Common.Core.Reflection;

namespace Common.Data
{
	public class DataStore
	{
		public int Count {
			get{
				return AllStore.Values.Count;
			}
		}


		private Store AllStore;
		private Dictionary<Type, Store> TypeStores;
		private Logger Log = LogManager.Create("DataStore");
		public static DataStore Instance = new DataStore();

		private DataStore ()
		{
			AllStore = new Store();
			TypeStores = new Dictionary<Type, Store> ();
			foreach( var t in ReflectionUtils.SubClassesOfAbstract (typeof(BasicData)) ) {
				TypeStores.Add (t, new Store ());
			}


		}

		public void AddData(BasicData data)
		{
			AllStore.Add (data.Id, data);
			TypeStores [data.GetType ()].Add (data.Id, data);
		}

		public IEnumerable<T> GetAllOfType<T>() where T : BasicData
		{
			return TypeStores [typeof(T)].Values.Cast<T> ();
		}

		public T GetData<T>(int id) where T : BasicData
		{
			return AllStore [id] as T;
		}



		private class Store : Dictionary<int, BasicData>
		{

		}
	}


}

