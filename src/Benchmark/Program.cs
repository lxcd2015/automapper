using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security;
using System.Threading;
using AutoMapper;
using Benchmark.Flattening;

[assembly: AllowPartiallyTrustedCallers]
//[assembly: SecurityTransparent]
//[assembly: SecurityRules(SecurityRuleSet.Level2, SkipVerificationInFullTrust = true)]

namespace Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var mappers = new Dictionary<string, IObjectToObjectMapper[]>
            //    {
            //        { "Flattening", new IObjectToObjectMapper[] { new FlatteningMapper() , new ManualMapper(), } },
            //        { "Ctors", new IObjectToObjectMapper[] { new CtorMapper(), new ManualCtorMapper(),  } },
            //        { "Complex", new IObjectToObjectMapper[] { new ComplexTypeMapper(), new ManualComplexTypeMapper() } },
            //        { "Deep", new IObjectToObjectMapper[] { new DeepTypeMapper(), new ManualDeepTypeMapper() } }
            //    };
            //foreach(var pair in mappers)
            //{
            //    foreach(var mapper in pair.Value)
            //    {
            //        new BenchEngine(mapper, pair.Key).Start();
            //    }
            //}

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>());
            var mapper = config.CreateMapper();

            OrderDto dto = mapper.Map<OrderDto>(new Order {
                Price=1024,
                SoId="111"
            });

            Console.WriteLine(dto);
            Console.ReadLine();
        }
    }

    public class Order
    {
        public string SoId { get; set; }

        public double Price { get; set; }
    }

    public class OrderDto
    {
        public string SoId { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return $"SoId:{SoId};Price:{Price.ToString("C2",new CultureInfo("zh-cn"))}";
        }
    }
}
