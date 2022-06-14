using Reflection_HW.Attributes;


namespace Reflection_HW.TestClasses
{
    class TestPropertyClass2
    {
        [ConfigurationItem("test_key_1_from_class_2", "test_value_1_from_class_2")]
        public string MyProperty { get; set; }
        [ConfigurationItem("test_key_2_from_class_2", "test_key_2_from_class_2")]
        public string MyProperty2 { get; set; }
    }
}
