using QuizInfermiere.Repository;
using System;

using Xamarin.Forms;

namespace QuizInfermiere
{
	public partial class RiepilogoPage : ContentPage
	{
		public RiepilogoPage()
		{
			InitializeComponent();

			Home.Clicked += homeButton_Clicked;


			using (var dati = new DataAccess())
			{
				var riepilogo = dati.GetRiepilogo();
				var categoria = dati.GetByID(riepilogo[0].IdCategoria);
				Categoria.Text = categoria.DesCategoria;
				int esatte = 0;
				int errate = 0;

				foreach (var recap in riepilogo)
				{
					if (recap.Esatta)
						esatte = esatte + 1;
					else
						errate = errate + 1;

				}

				errateLabel.Text = string.Format("{0} risposte sbagliate",errate.ToString());
				esatteLabel.Text = string.Format("{0} risposte esatte", esatte.ToString());

				RisposteList.ItemsSource = riepilogo;
			}


		}
		async void RiepilogoClick(object sender, SelectedItemChangedEventArgs e)
		{
			await Navigation.PushModalAsync(new RiepilogoDomandaPage(e.SelectedItem));

		}

		async void homeButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new QuizInfermierePage());
		}
	}
}

