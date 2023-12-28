using UnityEngine;
using System;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using System.Text;

public class APITest : MonoBehaviour
{

	public TMP_Text bestText;

	private void Start()
	{
		Query();
	}

	public async void SendResult(float Time)
	{
		string url = "http://192.168.81.121:5230/api/Rank";

		using (HttpClient client = new HttpClient())
		{
			try
			{
				// ������ ��� �������� (������)
				RankItem myRes = new RankItem
				{
					time = Time,
					playerName = "Test",
					gameVersion = "0.1v",
				};
				string jsonData = JsonConvert.SerializeObject(myRes);
				print(jsonData);

				// ����������� HTTP-�������� ��� JSON
				var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

				// �������� POST-������� � ��������� ������
				HttpResponseMessage response = await client.PostAsync(url, content);

				// �������� ������� ������
				if (response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();
					Debug.Log("�����: " + responseBody);
				}
				else
				{
					Debug.LogError("������: " + response.Content);
				}
			}
			catch (Exception e) {
				Debug.LogError("������: " + e.Message);
			}
		}
	}
	async void Query()
	{
		// URL ��� ������ API
		string url = "http://192.168.81.121:5230/api/";

		// �������� HttpClient
		using (HttpClient client = new HttpClient())
		{
			try
			{
				// �������� GET ������� � ��������� ������
				HttpResponseMessage response = await client.GetAsync(url+"Rank/best");

				// �������� ������� ������
				if (response.IsSuccessStatusCode)
				{
					// ��������� ������
					string responseBody = await response.Content.ReadAsStringAsync();
					RankItem playerData = JsonConvert.DeserializeObject<RankItem>(responseBody);
					bestText.text = $"{playerData.time}\n{playerData.playerName}";
				}
				else
				{
					Debug.LogError("������: " + response.ReasonPhrase);
				}
			}
			catch (Exception e)
			{
				Debug.LogError("������: " + e.Message);
			}
		}
	}
}
