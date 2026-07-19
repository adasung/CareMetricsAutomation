using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using FrameworkCore.Models;
using Reqnroll;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public class PatientTelemetrySteps
    {
     // 🌟 UPDATED: Removed RestClient/RestResponse. Initializing native types with standard null-forgiving operator.
        private HttpClient _httpClient = null!;
        private HttpResponseMessage _response = null!;
        private string _activePatientId = string.Empty;
        private const string TargetMockUrl = "https://httpbin.org/status/202"; // Public mock endpoint verifying response mechanics

        [Given(@"a patient client monitor with ID ""(.*)"" is active")]
        public void GivenAPatientClientMonitorWithIDIsActive(string patientId)
        {
            _activePatientId = patientId;
            
            // Instantiating natively. In production environments, this maps to IHttpClientFactory
            // to optimize socket lifecycle management and prevent TCP port exhaustion under heavy load.
            _httpClient = new HttpClient();
        }

        [When(@"the monitor transmits a streaming real-time vitals payload:")]
        public async Task WhenTheMonitorTransmitsAStreamingRealTimeVitalsPayload(Table table)
        {
            var row = table.Rows[0];
            
            var vitals = new VitalsPayload
            {
                PatientId = _activePatientId,
                HeartRate = int.Parse(row["HeartRate"]),
                SpO2 = int.Parse(row["SpO2"]),
                RespiratoryRate = int.Parse(row["RespiratoryRate"])
            };

            // Granular, low-level configuration of request headers for regulated data transfer
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // Native, high-performance asynchronous serialization and transmission
            _response = await _httpClient.PostAsJsonAsync(TargetMockUrl, vitals);
        }

        [Then(@"the distributed system response should confirm data ingestion with status code (.*)")]
        public void ThenTheDistributedSystemResponseShouldConfirmDataIngestion(int expectedStatusCode)
        {
            // Verifying the response state strictly using native NUnit platform engine assertions
            Assert.That(_response, Is.Not.Null, "The HTTP Response message was null.");
            
            int actualStatusCode = (int)_response.StatusCode;
            Assert.That(actualStatusCode, Is.EqualTo(expectedStatusCode), 
                $"Expected response status code {expectedStatusCode} but received {actualStatusCode}.");
        }
    }
}