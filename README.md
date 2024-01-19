# Ryuk
This class libray holds the following wage tax workflows:
- Workflow 2023 January - June
- Workflow 2023 July - December

# Installation
Add a github package reference:
```
dotnet nuget add source --username 'username' --password 'gh-token' --store-password-in-clear-text --name github "https://nuget.pkg.github.com/AK2083/index.json"
```
Add this package:
```
dotnet add package Ryuk --version 'version'
```

# Using
This library using the InputParameter to specify the wage tax parameters:

```
public class Main
{
	var app = new WageTaxWorkflow2023a(new InputParameter {
		LZZ = 1,
		KVZ = 1,
		PVS = 1,
		RE4 = Salary * 100
		JRE4 = Salary * 100
	})
	app.Init();

	WageTax = app.OutputPara.LSTLZZ
}
```