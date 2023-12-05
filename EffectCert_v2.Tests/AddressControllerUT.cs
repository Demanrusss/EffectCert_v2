using EffectCert.BLL.Contractors;
using EffectCert.Controllers.Contractors;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.DAL.Interfaces;
using EffectCert.ViewModels.Contractors;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EffectCert_v2.Tests
{
    public class AddressControllerUT
    {
        [Fact]
        public void Index_Returns_ViewResult_With_Addresses()
        {
            var mock = new Mock<AddressBLL>();
            mock.Setup(repo =>  repo.FindAll().Result).Returns(GetTestAddresses());
            var controller = new AddressController(mock.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ICollection<AddressBLL>>(viewResult.Model);
            Assert.Equal(GetTestAddresses().Count, model.Count);
        }

        private ICollection<AddressViewModel> GetTestAddresses()
        {
            return new List<AddressViewModel>()
            {
                new AddressViewModel() { Id = 1, Country = "World", Index = null, AddressLine = null },
                new AddressViewModel() { Id = 2, Country = "World", Index = "000000", AddressLine = null },
                new AddressViewModel() { Id = 3, Country = "World", Index = "000000", AddressLine = "Address Line" }
            };
        }
    }
}