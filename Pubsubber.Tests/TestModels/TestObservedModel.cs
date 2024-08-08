namespace Pubsubber.Tests.TestModels
{
    /// <summary>
    /// A test model which will be observed
    /// during testing.
    /// </summary>
    public sealed class TestObservedModel
    {
        public string Name { get; set; } = "";

        public Guid Id { get; set; } = Guid.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.MinValue;
    }
}
