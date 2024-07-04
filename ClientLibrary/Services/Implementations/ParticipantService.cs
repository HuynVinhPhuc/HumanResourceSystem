
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using System.Net.Http.Json;

namespace ClientLibrary.Services.Implementations
{
    public class ParticipantService(GetHttpClient getHttpClient) : IParticipantService
    {
        // Create
        public async Task<GeneralResponse> Insert(Participant item, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.PostAsJsonAsync($"{baseUrl}/add", item);
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }

        // Read All
        public async Task<List<Participant>> GetAll(string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var results = await httpClient.GetFromJsonAsync<List<Participant>>($"{baseUrl}/all");
            return results!;
        }

        // Read All Employee By TrainingProgramId
        public async Task<List<Participant>> GetAllEmployee(int trainingProgramId, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var results = await httpClient.GetFromJsonAsync<List<Participant>>($"{baseUrl}/all/employee/{trainingProgramId}");
            return results!;
        }

        // Read All Training Program By EmployeeId
        public async Task<List<Participant>> GetAllTrainingProgram(int employeeId, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var results = await httpClient.GetFromJsonAsync<List<Participant>>($"{baseUrl}/all/trainingprogram/{employeeId}");
            return results!;
        }

        // Read Single {id}
        public async Task<Participant> GetById(int trainingProgramId, int employeeId, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var result = await httpClient.GetFromJsonAsync<Participant>($"{baseUrl}/single/{trainingProgramId}&{employeeId}");
            return result!;
        }

        // Delete {id}
        public async Task<GeneralResponse> DeleteById(int trainingProgramId, int employeeId, string baseUrl)
        {
            var httpClient = await getHttpClient.GetPrivateHttpClient();
            var response = await httpClient.DeleteAsync($"{baseUrl}/delete/{trainingProgramId}&{employeeId}");
            var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
            return result!;
        }
    }
}
