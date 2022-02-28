using Spectre.Console;

namespace fluffy_split_scratch
{
	public class Program
	{
		public static void Main( string[] args )
		{
			SetupConsole();

			var url = GetConsoleInput();
			AnsiConsole.WriteLine( url );
			Console.ReadKey();
		}

		#region private methods

		/// <summary>
		/// Setup console output
		/// </summary>
		private static void SetupConsole()
		{
			AnsiConsole.Write(
				new FigletText( "Fluffy Split Scratch" )
					.Centered()
					.Color( Color.Maroon ) );
		}

		/// <summary>
		/// Get URL console input
		/// </summary>
		/// <returns>URL as string</returns>
		private static string GetConsoleInput()
		{
			while ( true )
			{
				var input = AnsiConsole.Ask<string>( "What URL to scratch? (example: https://www.example.com)" );

				Uri uriResult;

				if ( !string.IsNullOrEmpty( input ) )
				{
					bool result = Uri.TryCreate( input, UriKind.Absolute, out uriResult )
						&& ( uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps );

					if ( result )
					{
						return input;
					}
				}

				AnsiConsole.MarkupLine("[yellow]Input correct URL including protocol (example: https://www.example.com).[/]");
			}
		}

		#endregion
	}
}