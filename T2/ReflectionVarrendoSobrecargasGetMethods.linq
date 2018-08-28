<Query Kind="Program" />

void Main()
{
	var controller = new CambioController();

	var bindingFlags = 	BindingFlags.Instance | 
						BindingFlags.Static | 
						BindingFlags.Public | 
						BindingFlags.DeclaredOnly;
	
	var methodInfo = controller.GetType().GetMethods(bindingFlags);
	
	var args = new string[] { "moedaOrigem", "moedaDestino" };
	
	foreach(var metodo in methodInfo)
	{
		var parametros = metodo.GetParameters();
		
		if (!metodo.Name.Equals("Calcular")) continue;
		if (parametros.Length != args.Length) continue;
		
		var match = parametros.All(parametro => args.Contains(parametro.Name));
		
		if (match)
		{
			metodo.Dump();
			break;
		}
	}
}

// Define other methods and classes here
public class CambioController 
{
	public void Calcular(string moedaOrigem) {}
	public void Calcular(string moedaOrigem, string moedaDestino) {}
	public void Calcular(string moedaOrigem, string moedaDestino, decimal valor) {}
}