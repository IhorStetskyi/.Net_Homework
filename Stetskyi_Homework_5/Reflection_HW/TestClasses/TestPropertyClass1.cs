using Reflection_HW.Attributes;


namespace Reflection_HW.TestClasses
{
    class TestPropertyClass1
    {
        //[ConfigurationItem(1, 1.25)]
        //[ConfigurationItem("key1", "value1")]
        //[ConfigurationItem("key2(timestamp)", "0:10:0")]
        //[ConfigurationItem("key3", 333)]
        //[ConfigurationItem("key4", "value4")]
        [ConfigurationItem("test_key_1_from_class_1", "test_value_1_from_class_1")]
        public string MyProperty { get; set; }
        //[ConfigurationItem(5, "value5")]
        //[ConfigurationItem("key6", "value6")]
        [ConfigurationItem("test_key_2_from_class_1", "test_key_2_from_class_1")]
        public string MyProperty2 { get; set; }
    }
}
