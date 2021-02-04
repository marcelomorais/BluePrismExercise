# BluePrismExercise

This project has a appsettings.json where you can add your configurations, they are:
```DictionaryPath and ResultPath```

If you don't set any, this application will read from the dictionary first provided with name "word-dictionary.txt" and the result path will be inside the ```bin/``` folder in the file ```result.txt```

To execute the project open the main folder in your CMD and write:

```BluePrismExercise.exe ARG1 ARG2```
example:
```BluePrismExercise.exe SPIN SPOT```


Improvement areas:

Create Integration tests
Decrease the amount of private methods in order to be more testable
Create more unit tests to cover edge cases
Separate the SERVICE in a different .csproj making it more scalable.
Use a bit less redundancy to be easier to read.

