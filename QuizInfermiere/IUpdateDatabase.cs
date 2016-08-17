using System;
namespace QuizInfermiere
{
	public interface IUpdateDatabase
	{
		bool IsPresenteAggiornamento();
		bool UpdateData();

	}
}
