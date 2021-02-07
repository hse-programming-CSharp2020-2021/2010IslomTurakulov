using System;

namespace Veto
{
	class VetoVoter
	{
		static Random rnd = new Random();

		public VetoVoter(string name) => Name = name;
		public string Name { get; private set; }
		public void Vote(object sender, VetoEventArgs args)
		{
			if (args.VetoBy == null && rnd.Next(5) == 0)
				args.VetoBy = this;
		}
	}
	class VetoComission
	{
		public event EventHandler<VetoEventArgs> OnVote;

		public VetoEventArgs Vote(string proposal)
		{
			VetoEventArgs args = new VetoEventArgs();
			args.Proposal = proposal;
			OnVote?.Invoke(this, args);
			return args;
		}
	}
	class VetoEventArgs : EventArgs
	{
		public string Proposal { get; set; }
		public VetoVoter VetoBy { get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			VetoComission comission = new VetoComission();
			VetoVoter[] voters = new VetoVoter[5];
			for (int i = 0; i < 5; i++)
			{
				voters[i] = new VetoVoter($"MrVoter{i + 1}");
				comission.OnVote += voters[i].Vote;
			}
			string proposal = "Remove PogChamp from Twitch???";
			Console.WriteLine(proposal);
			VetoEventArgs result = comission.Vote(proposal);
			if (result.VetoBy == null)
				Console.WriteLine("No veto.");
			else
				Console.WriteLine($"Veto by {result.VetoBy.Name}!");
		}
	}
}
