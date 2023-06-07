using System;
using System.IO;
using YamlDotNet.Serialization;

namespace CSharpStudy
{
    class YamlRead
    {
        public void Read()
        {
            // YAML 파일을 읽어서 파싱
            using (StreamReader file = File.OpenText("config.yaml"))
            {
                var deserializer = new DeserializerBuilder().Build();
                var yamlData = deserializer.Deserialize<Person>(file);

                // 파싱된 데이터를 사용
                Console.WriteLine(yamlData.Name);
                Console.WriteLine(yamlData.Age);
            }
        }
    }
}
