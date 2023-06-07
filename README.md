#Yaml

C#에서 YAML 파일을 처리하기 위해서는 YamlDotNet 라이브러리를 사용할 수 있습니다. YamlDotNet은 C#에서 YAML 데이터를 파싱하고 직렬화하는 데 사용되는 인기 있는 라이브러리입니다.

먼저, YamlDotNet 라이브러리를 프로젝트에 추가해야 합니다. 이를 위해서는 NuGet 패키지 관리자를 사용하거나, 프로젝트 파일에 직접 패키지 의존성을 추가할 수 있습니다.

아래는 YamlDotNet을 사용하여 YAML 파일을 파싱하는 예시 코드입니다:

```csharp
using System;
using System.IO;
using YamlDotNet.Serialization;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main(string[] args)
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
```
위의 예시에서 Person 클래스는 YAML 파일에서 읽을 데이터 구조를 정의합니다. DeserializerBuilder를 사용하여 Deserialzer 객체를 생성하고, Deserialize<T> 메서드를 사용하여 YAML 파일을 파싱한 후 Person 객체로 변환합니다.

다음은 C#에서 객체를 YAML 파일로 직렬화하는 예시 코드입니다:
```csharp
using System;
using System.IO;
using YamlDotNet.Serialization;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var data = new Person
        {
            Name = "John",
            Age = 30
        };

        // 객체를 YAML로 직렬화하여 파일로 저장
        var serializer = new SerializerBuilder().Build();
        var yaml = serializer.Serialize(data);

        File.WriteAllText("output.yaml", yaml);
    }
}
```
위의 예시에서 SerializerBuilder를 사용하여 Serializer 객체를 생성하고, Serialize 메서드를 사용하여 Person 객체를 YAML 형식의 문자열로 변환한 후, File.WriteAllText 메서드를 사용하여 해당 문자열을 output.yaml 파일에 저장합니다.

이렇게 하면 C#에서 YAML 파일을 파싱하고 직렬화하는 과정을 간단하게 처리할 수 있습니다.
