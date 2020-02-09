using NUnit.Framework;
using JsonConverterDemo.Domain.Models;
using Newtonsoft.Json;
using CustomJsonConverter;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace JsonConverterDemo
{
    public class Tests
    {
        private JsonSerializerSettings _settings { get; set; } = new JsonSerializerSettings();
        private JsonSerializer _serializer => JsonSerializer.Create(_settings);

        [SetUp]
        public void Setup()
        {
            //setup serializers
            _settings.Converters.Add(new CustomConverter());
            
        }

        [Test]
        public void ComplexCustomClassSerializerOperationsAllWorkWithNull()
        {
            //setup objects to test on
            var testObj = new ComplexCustomClass();

            //execute tests
            var regularJson = JsonConvert.SerializeObject(testObj);
            var customJson = JsonConvert.SerializeObject(testObj, _settings);

            var regularObj = JObject.Parse(regularJson);
            var customObj = JObject.Parse(customJson);

            Assert.AreEqual(regularJson, customJson);
            Assert.AreEqual(regularObj, customObj);
        }

        [Test]
        public void ComplexCustomClassSerializerOperationsAllWorkWithData()
        {
            //setup objects to test on
            var testObj = new ComplexCustomClass();
            var list = new List<CustomClass>();
            list.Add(new CustomClass() { Name = "test" });
            testObj.Collection = list;

            //execute tests
            var regularJson = JsonConvert.SerializeObject(testObj);
            var customJson = JsonConvert.SerializeObject(testObj, _settings);

            var regularObj = JObject.Parse(regularJson);
            var customObj = JObject.Parse(customJson);

            Assert.AreEqual(regularJson, customJson);
            Assert.AreEqual(regularObj, customObj);
        }
    }
}