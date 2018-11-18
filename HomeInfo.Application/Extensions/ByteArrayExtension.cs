using ProtoBuf;
using System.IO;

namespace HomeInfo.Application.Extensions
{
    public static class ByteArrayExtension
    {
        public static byte[] Serialize<TRequest>(this TRequest request)
        {
            byte[] data;
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, request);
                data = ms.ToArray();
            }
            return data;
        }

        public static T Deserialize<T>(this byte[] data)
        {
            if (data == null || data.Length == 0)
                return default(T);

            using (MemoryStream ms = new MemoryStream(data))
            {
                return Serializer.Deserialize<T>(ms);
            }
        }
    }
}
