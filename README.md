# Attribute

Description에 대해서 확인을 하였다.    
Emum에 Description을 넣어 해당 문자를 출력 할 수 있다. (더 다양하게 사용 가능 할것으로 보인다.)   

```csharp
    public enum EnumScore
    {
        [Description("score 1")]
        SCORE01,
        [Description("score 2")]
        SCORE02,
        [Description("score 3")]
        SCORE03,
    }
```
또한 호출 하기 위해선 **정적** Class로 구성을 해야 한다.

```csharp
    static class AttributeDescription
    {
        public static string DescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return source.ToString();
            }
        }
    }
```

호출은 다음과 같이 수행하여 확인 하였다.

```csharp
        public MainWindow()
        {
            InitializeComponent();

            string _enumDescription = EnumScore.SCORE01.DescriptionAttr();
            MessageBox.Show(_enumDescription);
        }
```
