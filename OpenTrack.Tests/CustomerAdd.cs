using System.Collections.Generic;
using Xunit;
using OpenTrack;
using OpenTrack.Requests;
using OpenTrack.Responses;

namespace OpenTrack.Tests
{
    public class CustomerAdd
    {
        [Fact(Skip = "We do not want to add a new customer everytime we run tests.")]
        public void Customer_Add()
        {
            var api = Credentials.GetAPI();


            var request = new CustomerAddRequest(Credentials.EnterpriseCode, Credentials.DealerNumber, Settings.ServerName);
            var customer = new
            {
                FirstName = "Tom",
                LastName = "Monck",
                Email = "tom@asrpro.com"
            };
            // DT requires that you do a search for the entity first before you add.
            // They are trying to avoid duplicate customer records.
            // The search method returns a datatoken that is active for 15 minutes that you can use in an add request.
            string dataToken = null;
            try
            {
                var customerRequest = new CustomerSearchRequest(Credentials.EnterpriseCode, Credentials.DealerNumber)
                {
                    FirstName = customer.FirstName.ToUpper(),
                    LastName = customer.LastName.ToUpper(),
                    Email = customer.Email.ToUpper()
                };

                var searchResponse = api.FindCustomers(customerRequest);
                dataToken = searchResponse.DataToken;

            }
            catch (OpenTrackException openTrackException)
            {
                if (openTrackException.ErrorCode != "CS02") throw;

                var dataTokenElements = openTrackException.Response.GetElementsByTagName("DataToken");
                if (dataTokenElements.Count > 0)
                {
                    dataToken = dataTokenElements[0].InnerText;
                }

                request.Customer = new Customer
                {
                    DataToken = dataToken,
                    TypeCode = "C",
                    LastName = "Smith",
                    FirstName = "John",
                    MiddleName = "O",
                    Salutation = "Mr",
                    Gender = "Male",
                    Language = "English",
                    Address1 = "123 Main St",
                    Address2 = "Apt 103",
                    Address3 = "Test",
                    City = "Raleigh",
                    County = "Wake",
                    StateCode = "NC",
                    ZipCode = "27612",
                    PhoneNumber = "555-555-5555",
                    BusinessPhone = "555-555-5555",
                    BusinessExt = "426",
                    FaxNumber = "",
                    BirthDate = "",
                    DriversLicense = "",
                    Contact = "",
                    PreferredContact = "",
                    MailCode = "",
                    TaxExmptNumber = "",
                    AssignedSalesperson = "",
                    CustomerType = "R",
                    PreferredPhone = "",
                    CellPhone = "",
                    PagePhone = "",
                    OtherPhone = "",
                    OtherPhoneDesc = "",
                    Email1 = "1@1.com",
                    Email2 = "",
                    OptionalField = "",
                    AllowContactByPostal = "",
                    AllowContactByEmail = "Yes",
                    AllowContactByPhone = "",
                    BusinessPhoneExtension = "",
                    InternationalBusinessPhone = "",
                    InternationalCellPhone = "",
                    ExternalCrossReferenceKey = "",
                    InternationalFaxNumber = "",
                    InternationalOtherPhone = "",
                    InternationalHomePhone = "",
                    CustomerPreferredName = "",
                    InternationalPagerPhone = "",
                    PreferredLanguage = "",
                    InternationalZipCode = ""
                };

                var response = api.AddCustomer(request);
                Assert.NotNull(response);
            }
        }
    }
}
