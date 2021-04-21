using Francis_ABC.D365.Plugins.Core.Managers;
using Xunit;

namespace Francis_ABC.D365.UnitTests
{
  public class ContactManagerTest
  {
    [Fact]
    public void calculateClientAge()
    {
      int age = ContactManager.calculateAge(new System.DateTime(1992, 2, 29));
      Assert.Equal(29, age);
    }
  }
}
