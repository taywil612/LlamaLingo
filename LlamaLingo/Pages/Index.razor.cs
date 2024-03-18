using LlamaLingo.Models;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LlamaLingo.Pages
{
	public partial class Index
	{
#nullable enable

		private bool EnablePodDropDown = false;

		private List<Person>? people;

		private List<Pod>? pods;

		protected override async System.Threading.Tasks.Task OnInitializedAsync()
		{
			try
			{
				people = await getPeople();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		public async System.Threading.Tasks.Task<List<Person>> getPeople()
		{
			//Create a list containing all of the Person_IDs in the Person Table.
			List<Person> people = await db.Set<Person>().ToListAsync();

			return people;
		}

		public async System.Threading.Tasks.Task<List<Pod>> getPods(int personId)
		{
			//Create a list containing all of the POD Ids that a person can access.
			List<Pod> pods = await db.Pods.Where(p => p.PersonIdFk == personId).ToListAsync();

			return pods;
		}

		public async void ChangePerson(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, Person> args)
		{
			SelectedPod.CurrentPod = null;

			EnablePodDropDown = false;

			try
			{
				pods = await getPods(args.ItemData.PersonId);

				EnablePodDropDown = !string.IsNullOrEmpty(args.Value);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}

			StateHasChanged();
		}

		public void ChangePod(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, Pod> args)
		{
			SelectedPod.CurrentPod = args.ItemData;
		}
	}
}