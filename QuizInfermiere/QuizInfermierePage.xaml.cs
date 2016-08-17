using System.Collections.Generic;
using Xamarin.Forms;



namespace QuizInfermiere
{
	public partial class QuizInfermierePage : ContentPage
	{
		async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			await Navigation.PushModalAsync(new DomandePage(e.SelectedItem, 1, true, new List<Domanda>()));
		}


		public QuizInfermierePage()
		{
			InitializeComponent();

			#region


			//// queste categoria verranno pescate da DB 
			//var elencoCategorie = new List<Categorie>();
			//elencoCategorie.Add(new Categorie() { Categoria = "Simulazione" });
			//elencoCategorie.Add(new Categorie() { Categoria = "Quiz Emergenza ed Urgenza" });
			//elencoCategorie.Add(new Categorie() { Categoria = "Biologia" });
			//elencoCategorie.Add(new Categorie() { Categoria = "Infermieristica" });
			//elencoCategorie.Add(new Categorie() { Categoria = "Diritto Sanitario" });
			//elencoCategorie.Add(new Categorie() { Categoria = "Logica" });



			//var elencoDomande = new List<Domanda>();
			//elencoDomande.Add(new Domanda()
			//{
			//	IdCategoria = 1,
			//	Question = "Il codice di comportamento dei dipendenti delle Pubbliche Amministrazioni allegato al CCNL del comparto sanità recita, tra le altre cose che il dipendente pubblico......",
			//	NumeroDomanda = 1,
			//	RispostaUno = "Ispira le proprie decisioni ed i propri comportamenti alla cura dell'interesse esclusivamente personale",
			//	RispostaDue = "Ispira le proprie decisioni ed i propri comportamenti alla cura dell'interesse esclusivamente privato",
			//	RispostaTre = "Ispira le proprie decisioni ed i propri comportamenti alla cura dell'interesse pubblico che gli è affidato",
			//	RispostaQuattro = "Ispira le proprie decisioni ed i propri comportamenti alla cura dell'interesse esclusivamente dirigenziale",
			//	RispostaEsatta = "Ispira le proprie decisioni ed i propri comportamenti alla cura dell'interesse pubblico che gli è affidato"
			//});
			//elencoDomande.Add(new Domanda()
			//{
			//	IdCategoria = 1,
			//	Question = "Prova2???",
			//	NumeroDomanda = 2,
			//	RispostaUno = "Si2",
			//	RispostaDue = "no2",
			//	RispostaTre = "forse2",
			//	RispostaQuattro = "probabile2",
			//	RispostaEsatta = "no2"
			//});
			//elencoDomande.Add(new Domanda()
			//{
			//	IdCategoria = 1,
			//	Question = "Prova3???",
			//	NumeroDomanda = 3,
			//	RispostaUno = "Si3",
			//	RispostaDue = "no3",
			//	RispostaTre = "forse3",
			//	RispostaQuattro = "probabile3",
			//	RispostaEsatta = "no3"
			//});
			//elencoDomande.Add(new Domanda()
			//{
			//	IdCategoria = 1,
			//	Question = "Prova4???",
			//	NumeroDomanda = 4,
			//	RispostaUno = "Si4",
			//	RispostaDue = "no4",
			//	RispostaTre = "forse4",
			//	RispostaQuattro = "probabile4",
			//	RispostaEsatta = "no4"
			//});

			#endregion



			using (var dati = new DataAccess())
			{
				Listview.ItemsSource = dati.GetAllCategorie();



				//var categorieDB = dati.GetAllCategorie();
				//var domandeDB = dati.GetAllDomanda();



				//if (categorieDB.Count == 0)
				//{
				//	dati.InsertListCategorie(elencoCategorie);
				//	Listview.ItemsSource = dati.GetAll();
				//}

				//if (domandeDB.Count == 0)
				//{
				//	dati.InsertListDomande(elencoDomande);
				//}



			}

		}
	}
}

