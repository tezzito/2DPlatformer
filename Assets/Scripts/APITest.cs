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
				// Данные для отправки (пример)
				RankItem myRes = new RankItem
				{
					time = Time,
					playerName = "Test",
					gameVersion = "0.1v",
				};
				string jsonData = JsonConvert.SerializeObject(myRes);
				print(jsonData);

				// Определение HTTP-контента как JSON
				var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

				// Отправка POST-запроса и получение ответа
				HttpResponseMessage response = await client.PostAsync(url, content);

				// Проверка статуса ответа
				if (response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();
					Debug.Log("Ответ: " + responseBody);
				}
				else
				{
					Debug.LogError("Ошибка: " + response.Content);
				}
			}
			catch (Exception e) {
				Debug.LogError("Ошибка: " + e.Message);
			}
		}
	}
	async void Query()
	{
		// URL для вашего API
		string url = "http://192.168.81.121:5230/api/";

		// Создание HttpClient
		using (HttpClient client = new HttpClient())
		{
			try
			{
				// Отправка GET запроса и получение ответа
				HttpResponseMessage response = await client.GetAsync(url+"Rank/best");

				// Проверка статуса ответа
				if (response.IsSuccessStatusCode)
				{
					// Получение данных
					string responseBody = await response.Content.ReadAsStringAsync();
					RankItem playerData = JsonConvert.DeserializeObject<RankItem>(responseBody);
					bestText.text = $"{playerData.time}\n{playerData.playerName}";
				}
				else
				{
					Debug.LogError("Ошибка: " + response.ReasonPhrase);
				}
			}
			catch (Exception e)
			{
				Debug.LogError("Ошибка: " + e.Message);
			}
		}
	}
}
