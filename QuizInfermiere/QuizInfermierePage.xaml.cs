using QuizInfermiere.Contracts;
using QuizInfermiere.Repository;
using System;
using System.Collections.Generic;
using Xamarin.Forms;



namespace QuizInfermiere
{
	public partial class QuizInfermierePage : ContentPage
	{
		async void OnItemSelected(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new DomandePage(1, 1, true, new List<Domanda>()));
		}

        public QuizInfermierePage()
		{
			InitializeComponent();

			using (var dao = new DataAccess())
			{
				var lstCategorie = dao.AnaCategoria_GetAllCategorie();



                btn_2_0.Text = lstCategorie[0].DesCategoria;
                btn_2_1.Text = lstCategorie[1].DesCategoria;
                btn_2_2.Text = lstCategorie[2].DesCategoria;
                btn_3_0.Text = lstCategorie[3].DesCategoria;
                btn_3_1.Text = lstCategorie[4].DesCategoria;
                btn_3_2.Text = lstCategorie[5].DesCategoria;



            }

        }
	}
}

