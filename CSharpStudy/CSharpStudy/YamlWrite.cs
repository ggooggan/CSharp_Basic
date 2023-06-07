using System;
using System.IO;
using YamlDotNet.Serialization;

namespace CSharpStudy
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class YamlWrite
    {
        public void Write()
        {
            var data = new Person
            {
                Name = "John",
                Age = 30
            };

            // 객체를 YAML로 직렬화하여 파일로 저장
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(data);

            File.WriteAllText("config.yaml", yaml);
        }
    }
}
