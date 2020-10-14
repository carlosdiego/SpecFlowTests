using System;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using Services.Spec.Tests.DTO;
using TechTalk.SpecFlow;
using Xunit;

namespace Services.Spec.Tests.Steps
{
    [Binding]
    public class CreateUserSteps
    {
        private const string base_api = "https://localhost:44358";
        private readonly CreateUserRequest _createUserRequest;
        private IRestResponse _response;
        private IRestClient _restClient;
        private Random _num;
        public CreateUserSteps()
        {
            _createUserRequest = new CreateUserRequest();

            _restClient = new RestClient(base_api);

            _num = new Random();
        }

        [Given(@"I input name ""(.*)""")]
        public void GivenIInputName(string _name) => _createUserRequest.Name = _name + _num.Next();

        [Given(@"I input email ""(.*)""")]
        public void GivenIInputRole(string _email) => _createUserRequest.Email = _email;

        [When(@"I send create user request")]
        public void WhenISendCreateUserRequest()
        {
            var restRequest = new RestRequest("/api/User/AddUser", Method.POST) { RequestFormat = DataFormat.Json };
            restRequest.AddParameter("application/json", JsonConvert.SerializeObject(_createUserRequest), ParameterType.RequestBody);
            _response = _restClient.Execute(restRequest);
        }

        [Then(@"validate response is ok")]
        public void ThenValidateUserIsCreated() => Assert.True(_response.StatusCode == HttpStatusCode.OK);

    }
}
