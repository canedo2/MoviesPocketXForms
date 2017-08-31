using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using Newtonsoft.Json;
using Plugin.Connectivity;

namespace gistekpr
{
    public class AssignmentNetwork : IAssignmentNetwork<Assignment>
    {
        HttpClient client;
        IEnumerable<Assignment> assignments;

        public AssignmentNetwork()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            client.DefaultRequestHeaders.Add("Authorization", Settings.AuthToken);
            Console.WriteLine("SETTING AuthToken: " + Settings.AuthToken);
            assignments = new List<Assignment>();
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsAsync(bool forceRefresh = false)
        {
            try
            {
                if (forceRefresh && CrossConnectivity.Current.IsConnected)
                {
                    if (!Settings.CodDiversos.Equals(string.Empty))
                    {
                        var json = await client.GetStringAsync($"api/Assignment/diversos/"+Settings.CodDiversos);
                        var assignmentsDiversos = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Assignment>>(json));
                        assignments = assignments.Concat(assignmentsDiversos);
                    }
                    if (!Settings.CodAutos.Equals(string.Empty))
                    {
                        var json = await client.GetStringAsync($"api/Assignment/chapa/" + Settings.CodAutos);
                        var assignmentsChapa = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Assignment>>(json));
                        json = await client.GetStringAsync($"api/Assignment/mecanica/" + Settings.CodAutos);
                        var assignmentsMecanica = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Assignment>>(json));
                        assignments = assignments.Concat(assignmentsChapa);
                        assignments = assignments.Concat(assignmentsMecanica);
                    }
                }
                return assignments;
            }
            catch (Exception e)
            {
                Console.WriteLine("GetAssignmentsAsync Error: " + e.Message);
                return null;
            }
        }

		public async Task<bool> PutAssignmentAsync(Assignment assignment)
		{
            if (assignment == null || !CrossConnectivity.Current.IsConnected)
				return false;

            var serializedAssignment = JsonConvert.SerializeObject(assignment);
			var buffer = System.Text.Encoding.UTF8.GetBytes(serializedAssignment);
			var byteContent = new ByteArrayContent(buffer);

			var response = await client.PutAsync($"api/Assignment/", byteContent);

			return response.IsSuccessStatusCode ? true : false;
		}

        public async Task<IEnumerable<ComboBoxItem>> getComboBoxAsync(string department, int cod, int urte, int cia, string typeDoc = "FOTO") {
            try
            {

                IEnumerable<ComboBoxItem> comboBox = new List<ComboBoxItem>();

                if (CrossConnectivity.Current.IsConnected)
                {
                        var json = await client.GetStringAsync($"api/Assignment/comboBox/{department}/{cod}/{urte}/{cia}/{typeDoc}");
                        var comboBoxItems = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<ComboBoxItem>>(json));
                        comboBox = comboBoxItems;
                }
                return comboBox;
            }
            catch (Exception e)
            {
                Console.WriteLine("getComboVoxAsync Error: " + e.Message);
                return null;
            }
        }
    }
}
