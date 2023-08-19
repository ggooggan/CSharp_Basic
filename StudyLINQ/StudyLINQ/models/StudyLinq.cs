using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLINQ.models
{
    // LINQ (Language Integrated Query)

    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }

    public class Product
    {
        public string ProductName { get; set; }
        public string Star { get; set; }

        public class StudyLinq
        {
            Profile[] _arrProfiles;
            Product[] _arrProduct;
            public StudyLinq()
            {
                _arrProfiles = new Profile[5];
                _arrProfiles[0] = new Profile { Name = "정우성", Height = 186 };
                _arrProfiles[1] = new Profile { Name = "김태희", Height = 158 };
                _arrProfiles[2] = new Profile { Name = "고현정", Height = 172 };
                _arrProfiles[3] = new Profile { Name = "이문세", Height = 178 };
                _arrProfiles[4] = new Profile { Name = "하동훈", Height = 171 };

                _arrProduct = new Product[5];
                _arrProduct[0] = new Product {  ProductName = "비트", Star = "정우성" };
                _arrProduct[1] = new Product {  ProductName = "CF 다수", Star = "김태희" };
                _arrProduct[2] = new Product {  ProductName = "아이리스", Star = "김태희" };
                _arrProduct[3] = new Product {  ProductName = "모래시계", Star = "고현정" };
                _arrProduct[4] = new Product {  ProductName = "Solo예찬", Star = "이문세" };

            }

            public void Basic()
            {
                // 기본
                var profiels = from profile in _arrProfiles
                               where profile.Height < 175
                               orderby profile.Height
                               //select profile;
                               //select profile.Name;
                               select new { Name = profile.Name, Height = profile.Height * 0.393 }; // 무명 함수식

                foreach (var profile in profiels)
                {
                    Console.WriteLine($"{profile.Name} / {profile.Height}");
                    //Console.WriteLine(profile);
                }
            }


            public void GroupByStudy()
            {
                var listProfile = from profile in _arrProfiles
                                  group profile by profile.Height < 175 into g
                                  select new { GroupKey = g.Key, Profiles = g };

                foreach (var profile in listProfile)
                {
                    Console.WriteLine(profile.GroupKey.ToString());
                    foreach (var value in profile.Profiles)
                    {
                        Console.WriteLine(value.Name);
                    }
                }
            }

            public void JoinStudy()
            {
                /*
                두 데이터 원보을 연결하는 연산

                내부조인: 일종의교집합; 두데이터 원본 사이에서 일치하는 데이터만 연결하여 반환
                외부조인: 한쪽 데이터 원봉을 기준으로 삼은 상태에서 다른 데이터 원본과 결합하여 반환
                */

                var listProfile =
                    from profile in _arrProfiles
                    join product in _arrProduct
                    on profile.Name equals product.Star into ps
                    from sub_product in ps.DefaultIfEmpty(
                        new Product() { ProductName = "그런거 없음" })
                    select new
                    {
                        Name = profile.Name,
                        Work = sub_product.ProductName,
                        Height = profile.Height
                    };

                foreach (var profile in listProfile)
                {
                    Console.WriteLine(profile.Name);
                    Console.WriteLine(profile.Height);
                    Console.WriteLine(profile.Work);
                }

            }


            private void InnerJoin()
            {
                // 내부 조인
                var listProfile = from profile in _arrProfiles
                                  join product in _arrProduct
                                  on profile.Name equals product.Star
                                  select new { Name = profile.Name, Work = product.ProductName, Height = profile.Height };
                foreach (var profile in listProfile)
                {
                    Console.WriteLine(profile.Name);
                    Console.WriteLine(profile.Work);
                    Console.WriteLine(profile.Height);
                }
            }
        }
    }
}
