using QuizInfermiere.Repository;
using System;
using Xamarin.Forms;

namespace QuizInfermiere
{
	public partial class TotaleRispostePage : ContentPage
	{
		public TotaleRispostePage()
		{
			InitializeComponent();
			RiepilogoButton.Clicked += riepilogo_clicked;
			HomeButton.Clicked += home_clicked;

			using (var dati = new DataAccess())
			{
				var riepilogo = dati.GetRiepilogo();
				int esatte = 0;
				int errate = 0;

				foreach (var recap in riepilogo)
				{
					if (recap.Esatta)
						esatte = esatte + 1;
					else
						errate = errate + 1;

				}
				int totale = esatte + errate;
			

				int percentComplete = (int)Math.Round((double)(100 * esatte) / totale);

				if (percentComplete > 60)
				{
					PercentualeLabel.Text = "Complimenti, hai totalizzato il " + percentComplete.ToString() + "%.";

				}
				if (percentComplete > 40 && percentComplete < 60)
				{
					PercentualeLabel.Text = "Bravo, hai totalizzato il " + percentComplete.ToString() + "%.";
				}
				if (percentComplete < 40)
				{
					PercentualeLabel.Text = "Continua ad esercitarti, hai totalizzato il " + percentComplete.ToString() + "%.";
				}
			}
		}

		async void home_clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new QuizInfermierePage());
		}

		async void riepilogo_clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new RiepilogoPage());
		}


	}
}

