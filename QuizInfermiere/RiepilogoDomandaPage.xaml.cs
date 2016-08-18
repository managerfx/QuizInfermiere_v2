using QuizInfermiere.Contracts;
using QuizInfermiere.Repository;
using System;
using Xamarin.Forms;

namespace QuizInfermiere
{
    public partial class RiepilogoDomandaPage : ContentPage
	{
		public RiepilogoDomandaPage(object detail)
		{
			InitializeComponent();

			Home.Clicked += homeButton_Clicked;
			return_button.Clicked += Return_Button_Clicked;

			if (detail is int)
			{
				

			}
			else if (detail is RiepilogoRisposte)
			{
				var dettaglioRisposta = (detail as RiepilogoRisposte);


				using (var dati = new DataAccess())
				{
					Domanda.Text = dettaglioRisposta.Question;

					if (dettaglioRisposta.Esatta)
					{
						esatta_sbagliata.Text = "Complimenti, hai risposto in maniera esatta";
						esatta_sbagliata.TextColor = Color.Green;
						rispostaText.Text = dettaglioRisposta.RispostaData;
					}
					else
					{
						esatta_sbagliata.Text = "Peccato, hai risposto in maniera errata";
						esatta_sbagliata.TextColor = Color.Red;
						rispostaText.Text = dettaglioRisposta.RispostaData;
						esattaLabel.IsVisible = true;
						esatta_text.IsVisible = true;
						esatta_text.Text = dati.GetByIDCategoriaDomanda(dettaglioRisposta.IdCategoria, dettaglioRisposta.NumeroDomanda).RispostaEsatta;
					}


				}



			}



		}

		async void Return_Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new RiepilogoPage());
		}

		async void homeButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new QuizInfermierePage());
		}


	}
}

