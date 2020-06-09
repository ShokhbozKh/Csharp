using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace MiniProject01
{
    [Serializable]
    public abstract class ObjectPlus
    {
        private static IDictionary<Type, ICollection<ObjectPlus>> _extent =
            new Dictionary<Type, ICollection<ObjectPlus>>();

        public ObjectPlus()
        {
            if (!_extent.ContainsKey(GetType()))
            {
                _extent.Add(GetType(), new List<ObjectPlus>());
            }

            _extent[GetType()].Add(this);
        }

        public static IDictionary<Type, ICollection<ObjectPlus>> Extent
        {
            get
            {
                var result = new Dictionary<Type, ICollection<ObjectPlus>>();
                foreach (var k in _extent)
                {
                    result.Add(k.Key, k.Value.ToImmutableList());
                }

                return result;
            }
            set => _extent = value ?? throw new ArgumentNullException();
        }

        public static void SerializeToFile(string fileName)
        {
            var dictForSerialization = _extent.ToDictionary(x => x.Key.FullName, x => x.Value);
            using (Stream stream = File.Open(fileName, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, dictForSerialization);
            }
        }

        public static void DeserializeFromFile(string fileName)
        {
            using (Stream stream = File.Open(fileName, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                var deserializedDictionary =
                    (Dictionary<string, ICollection<ObjectPlus>>) formatter.Deserialize(stream);

                _extent = deserializedDictionary.ToDictionary(x => Type.GetType(x.Key), x => x.Value);
            }
        }
    }
}