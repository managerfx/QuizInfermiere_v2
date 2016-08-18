using QuizInfermiere.Contracts;
using QuizInfermiere.Repository;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace QuizInfermiere
{
	public partial class DomandePage : ContentPage
	{
		
		int domandaVisualizzare;//numero della domanda da visualizzare nella count;
		List<Domanda> dieciDomande;
	
		public DomandePage(object detail, int domanda, bool primapagina, List<Domanda> domande)
		{
			InitializeComponent();
			dieciDomande = domande;
			domandaVisualizzare = domanda;

			int categoriaID = 0;

			if (detail is int)
			{
				categoriaID = Convert.ToInt32(detail);

			}
			else if (detail is AnaCategoria)
			{
				categoriaID = (detail as AnaCategoria).IdCategoria;
				Titolo.Text = (detail as AnaCategoria).DesCategoria;
			}
			if (primapagina)
			{
				PopolaListaDomande(categoriaID);
			}
			Home.Clicked += homeButton_Clicked;



			NumeroQuiz.Text = domanda.ToString() + " / 10";
			NumeroDomanda.Text = "Domanda " + domanda.ToString();

			Domanda.Text = dieciDomande[domanda - 1].Question;






			var listaRisposte = new List<string>();
			listaRisposte.Add(dieciDomande[domanda-1].RispostaUno);
			listaRisposte.Add(dieciDomande[domanda - 1].RispostaDue);
			listaRisposte.Add(dieciDomande[domanda - 1].RispostaTre);
			listaRisposte.Add(dieciDomande[domanda - 1].RispostaQuattro);

			RispostaUnoLabel.Text = dieciDomande[domanda - 1].RispostaUno;
			RispostaUnoLabel.GestureRecognizers.Add(new TapGestureRecognizer((view) => RispostaClick(RispostaUnoLabel.Text)));

			RispostaDueLabel.Text = dieciDomande[domanda - 1].RispostaDue;
			RispostaDueLabel.GestureRecognizers.Add(new TapGestureRecognizer((view) => RispostaClick(RispostaDueLabel.Text)));
			RispostaTreLabel.Text = dieciDomande[domanda - 1].RispostaTre;
			RispostaTreLabel.GestureRecognizers.Add(new TapGestureRecognizer((view) => RispostaClick(RispostaTreLabel.Text)));
			RispostaQuattroLabel.Text = dieciDomande[domanda - 1].RispostaQuattro;
			RispostaQuattroLabel.GestureRecognizers.Add(new TapGestureRecognizer((view) => RispostaClick(RispostaQuattroLabel.Text)));


            RiepilogoRisposte risposta = new RiepilogoRisposte();
			risposta.IdCategoria = categoriaID;
			risposta.NumeroDomanda = dieciDomande[domanda - 1].NumeroDomanda;
			risposta.Question = dieciDomande[domanda - 1].Question;
			risposta.RispostaData = dieciDomande[domanda - 1].RispostaEsatta;
			using (var dati = new DataAccess())
				dati.InsertRisposta(risposta);
		}

		async void homeButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new QuizInfermierePage());
		}

		public List<Domanda> PopolaListaDomande(int idCategoria)
		{
			using (var dati = new DataAccess())
			{
				var numeroDomande = dati.GetMaxDomande(idCategoria);
				dati.DeleteRisposte();


				Random rand = new Random();
				List<int> result = new List<int>();
				HashSet<int> check = new HashSet<int>();
				for (Int32 i = 0; i < numeroDomande; i++)
				{
					int curValue = rand.Next(1, numeroDomande+1);
					while (check.Contains(curValue))
					{
						curValue = rand.Next(1, numeroDomande+1);
					}
					result.Add(curValue);
					check.Add(curValue);
				}

				List<Domanda> listaDomande = new List<Domanda>();

				foreach (var nDomanda in result)
				{
					listaDomande.Add(dati.GetByIDCategoriaDomanda(idCategoria, nDomanda));
				}

				dieciDomande = listaDomande;
				return listaDomande;
			}
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			using (var dati = new DataAccess())
			{
				var risposta = dati.GetUltimaDomanda();
				if (risposta.RispostaData == e.SelectedItem.ToString())
				{
					risposta.Esatta = true;
				}
				else
				{
					risposta.RispostaData = e.SelectedItem.ToString();
				}
				dati.UpdateRisposta(risposta);

				var categoria = dati.GetByID(risposta.IdCategoria);
				domandaVisualizzare = domandaVisualizzare + 1;

				if (dieciDomande.Count + 1 == domandaVisualizzare)
					await Navigation.PushModalAsync(new RiepilogoPage());
				else
				await Navigation.PushModalAsync(new DomandePage(categoria, domandaVisualizzare, false,dieciDomande));
			}
		}

		async void RispostaClick(object sender, EventArgs e)
		{
			using (var dati = new DataAccess())
			{
				var risposta = dati.GetUltimaDomanda();
				if (risposta.RispostaData == e.ToString())
				{
					risposta.Esatta = true;
				}
				else
				{
					risposta.RispostaData = e.ToString();
				}
				dati.UpdateRisposta(risposta);

				var categoria = dati.GetByID(risposta.IdCategoria);
				domandaVisualizzare = domandaVisualizzare + 1;

				if (dieciDomande.Count + 1 == domandaVisualizzare)
					await Navigation.PushModalAsync(new RiepilogoPage());
				else
					await Navigation.PushModalAsync(new DomandePage(categoria, domandaVisualizzare, false, dieciDomande));
			}
		}

		async void RispostaClick(string e)
		{
			using (var dati = new DataAccess())
			{
				var risposta = dati.GetUltimaDomanda();
				if (risposta.RispostaData == e.ToString())
				{
					risposta.Esatta = true;
				}
				else
				{
					risposta.RispostaData = e.ToString();
				}
				dati.UpdateRisposta(risposta);

				var categoria = dati.GetByID(risposta.IdCategoria);
				domandaVisualizzare = domandaVisualizzare + 1;

				if (dieciDomande.Count + 1 == domandaVisualizzare)
					await Navigation.PushModalAsync(new TotaleRispostePage());
				else
					await Navigation.PushModalAsync(new DomandePage(categoria, domandaVisualizzare, false, dieciDomande));
			}
		}

	}
}

